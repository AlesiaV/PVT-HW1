using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song
    {
        public int Duration; //длина песни
        public string Name; //название песни
        public Artist Artist; // класс артист
        public Album Album; //класс альбом
        public bool? Like = null; //нравится/ненравится песня
        public Artist.Genres Genres; //жанр песни

        public void LikeSong()
        {
            Like = true;
        }

        public void DislikeSong()
        {
            Like = false;
        }

        public string SetColoreOfSong()
        {
            if (Like == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return Name;
            }
            else if (Like == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return Name;
            }

            //Console.WriteLine($"Playing: {Name}, Genre: {Artist.Genre}, Duration: {Duration}\n");
            Console.ResetColor();
            return Name;
        }
    }
}
