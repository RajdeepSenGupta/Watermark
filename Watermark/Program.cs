using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Watermark
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceImage = "";                                            // Image Path
            string watermark = "Watermark";

            Image image = Image.FromFile(sourceImage);

            Graphics graphic;
            if (image.PixelFormat != PixelFormat.Indexed && image.PixelFormat != PixelFormat.Format8bppIndexed && image.PixelFormat != PixelFormat.Format4bppIndexed && image.PixelFormat != PixelFormat.Format1bppIndexed)
            {
                graphic = Graphics.FromImage(image);
            }
            else
            {
                Bitmap indexedImage = new Bitmap(image);
                graphic = Graphics.FromImage(indexedImage);

                // Draw the contents of the original bitmap onto the new bitmap.
                graphic.DrawImage(image, 0, 0, image.Width, image.Height);
                image = indexedImage;
            }

            graphic.SmoothingMode = SmoothingMode.AntiAlias & SmoothingMode.HighQuality;

            //This is the font for your watermark
            Font myFont = new Font("Arial", 20);
            SolidBrush brush = new SolidBrush(Color.LightSlateGray);

            //This gets the size of the graphic
            SizeF textSize = graphic.MeasureString(watermark, myFont);

            // Code for writing text on the image and showing its postion on images.
            PointF pointF = new PointF(1200, 200);
            graphic.DrawString(watermark, myFont, brush, pointF);
            
			
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save("");                                                             // NewImage Path
            }
        }
    }
}
