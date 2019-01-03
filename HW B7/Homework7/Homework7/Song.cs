using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    public class Song: IEquatable<Song>
    {
        private string _lyrics;
        public string Lyrics {get; set;}

        public Song(string lyrics)
        {
            _lyrics = lyrics;
        }

        public override string ToString()
        {
            return "Lyrics: " + _lyrics;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Song objAsSong = obj as Song;
            if (objAsSong == null) return false;
            else return Equals(objAsSong);
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public bool Equals(Song other)
        {
            if (other == null) return false;
            return (this.Lyrics.Equals(other.Lyrics));
        }
    }
}
