using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleImageProcessingApplication
{
    public abstract class BasicClass
    {
        public FileInfo[] _Files;
        public string newPathDirectory;
        public abstract void ImageProcessAppl();

        public BasicClass(string patDir, string nameCom)
        {
            DirectoryInfo directory = new DirectoryInfo(patDir);
            newPathDirectory = patDir + nameCom;

            if (directory.Exists)
            {
                var newDirectory = new DirectoryInfo(newPathDirectory);
                if (!newDirectory.Exists)
                {
                    newDirectory.Create();
                }
            }
            else Console.WriteLine("Error! Directory missing.");

            _Files = directory.GetFiles(@"*.jpg");
        }
    }
}
