using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            //player.Volume = 20;
            player.Songs = GetSongsData();

            //TraceInfo(player);

            player.Play();
            player.VolumeUp();
            Console.WriteLine(player.Volume);

            player.VolumeDown();

            player.VolumeChange(-300);
            Console.WriteLine(player.Volume);

            player.VolumeChange(500);
            Console.WriteLine(player.Volume);

            /*player.Volume = -25;
            Console.WriteLine(player.Volume);
            */

            player.Stop();
            player.Lock();
            player.Unlock();
            //player.Playing = false;

            var exampleSong = CreateSong();
            Console.WriteLine($"CreateDefaultSong: {exampleSong.Duration}, {exampleSong.Name}, " +
                $"{exampleSong.Artist.Name}, {exampleSong.Album.Name}");

            var exampleSong2 = CreateSong("First_Song");
            Console.WriteLine($"CreateNamedSong: {exampleSong2.Duration}, {exampleSong2.Name}, " +
                $"{exampleSong2.Artist.Name}, {exampleSong2.Album.Name}");

            var exampleSong3 = CreateSong(300, "Best_Song", new Album ("Hello", 2009), new Artist ("Light", "Pop"));
            Console.WriteLine($"CreateSong: {exampleSong3.Duration}, {exampleSong3.Name}, " +
                $"{exampleSong3.Artist.Name}, {exampleSong3.Album.Name}");



            Console.ReadLine();
        }

        public static Song[] GetSongsData()
        {
            var artist = new Artist();
            artist.Name = "Powerwolf";
            artist.Genre = "Metal";

            var artist2 = new Artist("Lordi");
            Console.WriteLine(artist2.Name);
            Console.WriteLine(artist2.Genre);

            var artist3 = new Artist("Sabaton", "Rock");
            Console.WriteLine(artist3.Name);
            Console.WriteLine(artist3.Genre);

            var album = new Album();
            album.Name = "New Album";
            album.Year = 2018;

            var song = new Song()
            {
                Duration = 100,
                Name = "New song",
                Album = album,
                Artist = artist
            };

            return new Song[] {song};
        }

        public static void TraceInfo(Player player)
        {
            Console.WriteLine(player.Songs[0].Artist.Name);
            Console.WriteLine(player.Songs[0].Duration);
            Console.WriteLine(player.Songs.Length);
            Console.WriteLine(player.Volume);
        }
        //method CreateDefaultSong:
        public static Song CreateSong()
        {
            return new Song
            {
                Duration = 5,
                Name = "Unknown_Song",
                Album = new Album(),
                Artist = new Artist()
            };
        }
        //method CreateNamedSong:
        public static Song CreateSong(string name)
        {
            return new Song
            {
                Duration = 5,
                Name = name,
                Album = new Album(),
                Artist = new Artist()
            };
        }

        public static Song CreateSong(int duration, string name, Album album, Artist artist)
        {
            return new Song
            {
                Duration = duration,
                Name = name,
                Album = album,
                Artist = artist
            };
        }
    }
}
