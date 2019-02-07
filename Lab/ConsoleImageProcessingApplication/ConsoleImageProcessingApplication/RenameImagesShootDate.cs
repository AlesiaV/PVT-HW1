using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ConsoleImageProcessingApplication.Extensions;



namespace ConsoleImageProcessingApplication
{
    class RenameImagesShootDate : BasicClass
    {
        public RenameImagesShootDate(string patDir, string nameDir) : base(patDir, nameDir)
        {

        }

        public override void ImageProcessAppl()
        {
            foreach (var file in Files)
            {
                using (Image image = Image.FromFile(file.FullName))
                {
                    //var propItemsDate = image.GetPropertyItem(0x9003);
                    //string fileName = Encoding.UTF8.GetString(propItemsDate.Value).Replace(':', '.').Substring(0, 16);
                    string fileName = image.GetFileDate();
                    file.CopyTo(newPathDirectory + fileName + file.Name);
                }
            }
        }
    }
}
