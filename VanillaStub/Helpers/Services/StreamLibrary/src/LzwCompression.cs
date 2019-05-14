using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VanillaStub.Helpers.Services.StreamLibrary.src
{
    public class LzwCompression
    {
        private readonly ImageCodecInfo encoderInfo;
        private readonly EncoderParameters encoderParams;
        private readonly EncoderParameter parameter;

        public LzwCompression(int Quality)
        {
            parameter = new EncoderParameter(Encoder.Quality, Quality);
            encoderInfo = GetEncoderInfo("image/jpeg");
            encoderParams = new EncoderParameters(2);
            encoderParams.Param[0] = parameter;
            encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, (long) EncoderValue.CompressionLZW);
        }

        public byte[] Compress(Bitmap bmp, byte[] AdditionInfo = null)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (AdditionInfo != null)
                    stream.Write(AdditionInfo, 0, AdditionInfo.Length);
                bmp.Save(stream, encoderInfo, encoderParams);
                return stream.ToArray();
            }
        }

        public void Compress(Bitmap bmp, Stream stream, byte[] AdditionInfo = null)
        {
            if (AdditionInfo != null)
                stream.Write(AdditionInfo, 0, AdditionInfo.Length);
            bmp.Save(stream, encoderInfo, encoderParams);
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < imageEncoders.Length; i++)
                if (imageEncoders[i].MimeType == mimeType)
                    return imageEncoders[i];
            return null;
        }
    }
}