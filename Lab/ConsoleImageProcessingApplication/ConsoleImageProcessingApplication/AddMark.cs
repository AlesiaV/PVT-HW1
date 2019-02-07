using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ConsoleImageProcessingApplication.Extensions;

namespace ConsoleImageProcessingApplication
{
    class AddMark : BasicClass
    {
        public AddMark(string patDir, string nameDir) : base(patDir, nameDir)
        {

        }

        public override void ImageProcessAppl()
        {
            foreach (var file in Files)
            {
                using (Image image = Image.FromFile(file.FullName))
                {
                    //var propItemsDate = image.GetPropertyItem(0x9003);
                    //string fileDate = Encoding.UTF8.GetString(propItemsDate.Value).Replace(':', '.').Substring(0, 16);

                    string fileDate = image.GetFileDate();

                    using (Graphics drawing = Graphics.FromImage(image))
                    {
                        RectangleF drawRect = new RectangleF(image.Width - 500, 0, 0, 0);
                        drawing.DrawString(fileDate, new Font("Calibri", 60), Brushes.DarkRed, drawRect);
                    }

                    image.Save(newPathDirectory + file.Name);
                }
            }
        }
    }
}
