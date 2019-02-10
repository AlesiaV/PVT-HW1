using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ConsoleImageProcessingApplication.Extensions;
using System.Net;
using System.Xml.Linq;
using System.Xml;

namespace ConsoleImageProcessingApplication
{
    class SortByLocation : BasicClass
    {
        public SortByLocation(string patDir, string nameDir) : base(patDir, nameDir)
        {

        }

        public override void ImageProcessAppl()
        {
            foreach (var file in _Files)
            {
                using (Image image = Image.FromFile(file.FullName))
                {
                    try
                    {
                        PropertyItem item1 = image.GetPropertyItem(1);
                        PropertyItem item2 = image.GetPropertyItem(2);
                        PropertyItem item3 = image.GetPropertyItem(3);
                        PropertyItem item4 = image.GetPropertyItem(4);

                        string fileDate;
                        string latitude = BitConverter.ToChar(item1.Value, 0).ToString() + DecodeRational64u(item2);
                        string longitude = BitConverter.ToChar(item3.Value, 0).ToString() + DecodeRational64u(item4);
                        string geocode = latitude + "," + longitude;

                        WebRequest request = WebRequest.Create($"https://geocode-maps.yandex.ru/1.x/?geocode={geocode}");
                        WebResponse response = request.GetResponse();
                        
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string str = reader.ReadToEnd();
                                int index1 = str.IndexOf("text");
                                int index2 = str.IndexOf("/text");
                                fileDate = str.Substring(index1 + 5, index2 - index1 - 6);
                            }
                        }
                        response.Close();

                        var newDirByLocation = new DirectoryInfo(newPathDirectory + @"\");
                        if (!newDirByLocation.Exists)
                        {
                            newDirByLocation.Create();
                        }
                        file.CopyTo(newDirByLocation + fileDate +","+ file.Name);
                    }
                    catch(Exception)
                    {
                        Console.WriteLine($"{file.Name} - not exists GPS coordinates of city");
                    }
                }
            }
        }

        private static string DecodeRational64u(PropertyItem propertyItem)
        {
            uint dN = BitConverter.ToUInt32(propertyItem.Value, 0);
            uint dD = BitConverter.ToUInt32(propertyItem.Value, 4);
            uint mN = BitConverter.ToUInt32(propertyItem.Value, 8);
            uint mD = BitConverter.ToUInt32(propertyItem.Value, 12);
            uint sN = BitConverter.ToUInt32(propertyItem.Value, 16);
            uint sD = BitConverter.ToUInt32(propertyItem.Value, 20);

            decimal deg;
            decimal min;
            decimal sec;

            if (dD > 0) { deg = (decimal)dN / dD; } else { deg = dN; }
            if (mD > 0) { min = (decimal)mN / mD; } else { min = mN; }
            if (sD > 0) { sec = (decimal)sN / sD; } else { sec = sN; }

            if (sec == 0) return string.Format($"{deg}° {min:0.###}'");
            else return string.Format($"{deg}° {min:0}' {sec:0.#}\"");
        }
    }
}
