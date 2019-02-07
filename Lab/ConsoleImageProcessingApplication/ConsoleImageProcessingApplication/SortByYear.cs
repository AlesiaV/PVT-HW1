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
            foreach (var file in Files)
            {
                using (Image image = Image.FromFile(file.FullName))
                {
                    //var propItemsDate = image.GetPropertyItem(0x9003);
                    //string fileDate = Encoding.UTF8.GetString(propItemsDate.Value).Replace(':', '.').Substring(0, 4);

                    string fileDate = image.GetFileDate().Substring(0, 4);
                    
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
