using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song : PlayingItem
    {
        public Artist.Genres Genres; //жанр песни

        public string Path { get; internal set; }

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
