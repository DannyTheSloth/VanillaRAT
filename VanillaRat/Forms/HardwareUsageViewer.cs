using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class HardwareUsageViewer : Form
    {
        public HardwareUsageViewer()
        {
            InitializeComponent();
            Update = true;
            MinimizeBox = false;
            MaximizeBox = false;
            UpdateForm = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }
        public bool UpdateForm { get; set; }

        //Set up charts
        private void InitCharts()
        {
            ucCpu.Series.Clear();
            ucCpu.Palette = ChartColorPalette.BrightPastel;
            ucCpu.Titles.Add("CPU Usage");
            Series SCPU = ucCpu.Series.Add("CPU Usage");
            ucCpu.Series[0].ChartType = SeriesChartType.FastLine;
            SCPU.Points.Add(0);
            ucCpu.Series[0].YAxisType = AxisType.Primary;
            ucCpu.Series[0].YValueType = ChartValueType.Int32;
            ucCpu.Series[0].IsXValueIndexed = false;
            ucCpu.ResetAutoValues();
            ucCpu.ChartAreas[0].AxisY.Maximum = 100;
            ucCpu.ChartAreas[0].AxisY.Minimum = 0;
            ucCpu.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            ucCpu.ChartAreas[0].AxisY.Title = "CPU Usage %";
            ucCpu.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            ucDisk.Series.Clear();
            ucDisk.Palette = ChartColorPalette.BrightPastel;
            ucDisk.Titles.Add("Disk Usage");
            Series SDISK = ucDisk.Series.Add("Disk Usage");
            ucDisk.Series[0].ChartType = SeriesChartType.FastLine;
            SDISK.Points.Add(0);
            ucDisk.Series[0].YAxisType = AxisType.Primary;
            ucDisk.Series[0].YValueType = ChartValueType.Int32;
            ucDisk.Series[0].IsXValueIndexed = false;
            ucDisk.ResetAutoValues();
            ucDisk.ChartAreas[0].AxisY.Maximum = 100;
            ucDisk.ChartAreas[0].AxisY.Minimum = 0;
            ucDisk.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            ucDisk.ChartAreas[0].AxisY.Title = "Disk Usage %";
            ucDisk.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            Update = true;
            bwUpdateCharts.RunWorkerAsync();
        }

        //Stop usage stream
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (Update && bwUpdateCharts.IsBusy)
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopUsageStream"));
                bwUpdateCharts.CancelAsync();
                Update = false;
                btnStop.Text = "Start";
            }
            else if (!Update && !bwUpdateCharts.IsBusy)
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StartUsageStream"));
                Update = true;
                bwUpdateCharts.RunWorkerAsync();
                btnStop.Text = "Stop";
            }
        }

        //On CPU change
        private void txtCpuUsage_TextChanged(object sender, EventArgs e) { }

        //On disk change
        private void txtDiskUsage_TextChanged(object sender, EventArgs e) { }

        //On ram Change
        private void txtAvailableRam_TextChanged(object sender, EventArgs e) { }

        //Stop usage stream
        private void HardwareUsageViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateForm = false;
            Update = false;
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopUsageStream"));
            AutoClosingMessageBox.Show("Waiting for usage stream to stop.", "Waiting", 1000);
        }

        //On form load
        private void HardwareUsageViewer_Load(object sender, EventArgs e)
        {
            InitCharts();
        }

        //Update Charts
        private void bwUpdateCharts_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Update)
            {
                Invoke(new MethodInvoker(() =>
                {
                    try
                    {
                        int CpuUsage = Convert.ToInt32(txtCpuUsage.Text);
                        ucCpu.Series[0].Points.AddY(CpuUsage);
                        if (ucCpu.Series[0].Points.Count > 40)
                            ucCpu.Series[0].Points.RemoveAt(0);
                        int DiskUsage = Convert.ToInt32(txtDiskUsage.Text);
                        ucDisk.Series[0].Points.AddY(DiskUsage);
                        if (ucDisk.Series[0].Points.Count > 40)
                            ucDisk.Series[0].Points.RemoveAt(0);
                    }
                    catch { }
                }));
                Thread.Sleep(450);
            }
        }
    }
}