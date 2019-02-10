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
    class SortByYear : BasicClass
    {
        public SortByYear(string patDir, string nameDir) : base(patDir, nameDir)
        {

        }
        public override void ImageProcessAppl()
        {
            foreach (var file in _Files)
            {
                using (Image image = Image.FromFile(file.FullName))
                {
                    string fileDate = image.GetFileYear().Substring(0, 4);
                    
                    var newDirByYear = new DirectoryInfo(newPathDirectory + fileDate + @"\");

                    if (!newDirByYear.Exists)
                    {
                        newDirByYear.Create();
                    }

                    file.CopyTo(newDirByYear + file.Name);
                }
            }
        }
    }
}
