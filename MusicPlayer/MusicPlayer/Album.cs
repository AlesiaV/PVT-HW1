using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Album
    {
        public byte[] Picture;
        public string Name;
        public int Year;

        public Album()
        {
            this.Name = "Default album";
            this.Year = 0;
        }

        public Album(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }
    }
}
