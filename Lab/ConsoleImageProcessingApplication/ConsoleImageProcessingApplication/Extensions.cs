using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ConsoleImageProcessingApplication.Extensions
{
    static class Extensions
    {
        public static string GetFileDate (this Image image)
        {
            var propItemsDate = image.GetPropertyItem(0x9003);
            string fileDate = Encoding.UTF8.GetString(propItemsDate.Value).Replace(':', '.').Substring(0, 16);

            return fileDate;
        }
    }
}
