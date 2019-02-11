using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Artist
    {
        public string Genre; //жанр песен артиста
        public string Name; //имя артиста или группы

        public Artist()
        {
            this.Name = "Default artist unknown";
            this.Genre = "Default genre unknown";
        }

        public Artist(string name)
        {
            this.Name = name;
            this.Genre = "Default genre unknown";
        }

        public Artist(string name, string genre)
        {
            this.Name = name;
            this.Genre = genre;
        }
        
        public enum Genres {Undefined, Pop, Disco, PopRock, Metal, Jazz};

        //[Flags]
        //public enum Genres
        //{
        //    Undefined = 0b00000000,
        //    Pop = 0b00000001,
        //    Disco = 0b00000010,
        //    PopRock = 0b00000100,
        //    Metal = 0b00001000,
        //    Jazz = 0b00010000,
        //};
    }
}

