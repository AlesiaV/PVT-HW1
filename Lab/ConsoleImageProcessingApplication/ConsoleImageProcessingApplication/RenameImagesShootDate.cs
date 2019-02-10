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
            foreach (var file in _Files)
            {
                using (Image image = Image.FromFile(file.FullName))
                {
                    string fileName = image.GetFileDate();
                    file.CopyTo(newPathDirectory + fileName + file.Name);
                }
            }
        }
    }
}
