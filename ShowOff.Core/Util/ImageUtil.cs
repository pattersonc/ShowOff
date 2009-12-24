using System;
using System.Data;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace ShowOff.Core.Util
{
    public class ImageUtil
    {
        public static void ResizeImage(string fileName, int newWidth)
        {
            var fi = new FileInfo(fileName);

            if(!fi.Exists)
                throw new ArgumentException(fileName + " does not exist.");

            Bitmap newbmp;

            using (Bitmap originalBitmap = Bitmap.FromFile(fileName, true) as Bitmap)
            {
                float ratio = (float)newWidth / (float)originalBitmap.Width;
                double newHeight = (ratio) * originalBitmap.Height;

                newbmp = new Bitmap(newWidth, (int)newHeight);

                using (Graphics newg = Graphics.FromImage(newbmp))
                {
                    newg.DrawImage(originalBitmap, 0, 0, (float)newWidth, (float)newHeight);
                    newg.Save();
                }
            }

            newbmp.Save(fileName, ImageFormat.Jpeg);
            newbmp.Dispose();
        }
    }
}
