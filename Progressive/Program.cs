using ImageMagick;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Progressive
{
    class Program
    {

        static Stream ToProgressive(Stream img)
        {
            Stream res = new MemoryStream();
            ToProgressive(img, res);
            res.Seek(0, SeekOrigin.Begin);
            return res;
        }

        static void ToProgressive(Stream img, Stream outStream)
        {
            using (MagickImage image = new MagickImage(img))
            {
                // Set the format and write to a stream so ImageMagick won't detect the file type.
                image.Format = MagickFormat.Pjpeg;
                image.Write(outStream);

            }
        }

        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(args[0], FileMode.Open))
            using (FileStream outFs = new FileStream(args[1], FileMode.Create))
            {
                //Stream imgStream = ToProgressive(fs);
                //imgStream.CopyTo(outFs);
                ToProgressive(fs, outFs);
            };
        }
    }
}
