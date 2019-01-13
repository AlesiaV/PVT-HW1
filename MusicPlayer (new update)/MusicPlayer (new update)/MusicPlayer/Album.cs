using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Album
    {
        public List<byte> Picture; // обложка альбома
        public string Name; //название альбома
        public int Year; //год выпуска альбома

        public Album()
        {
            this.Name = "Default album unknown";
            this.Year = 0;
        }

        public Album(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }
    }
}
