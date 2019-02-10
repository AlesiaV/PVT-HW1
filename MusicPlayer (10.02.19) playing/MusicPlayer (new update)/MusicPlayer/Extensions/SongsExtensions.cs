using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Extensions
{
    static class SongsExtensions
    {
        static public string ModifiedOfSongsName(this string name, int sizeOfName)
        {
            if (name.Length > sizeOfName)
            {
                return name.Substring(0, sizeOfName) + "...";
            }
            return name;
        }
    }
}
