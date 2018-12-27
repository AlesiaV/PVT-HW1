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
            int totalDuration = 0;
            player.Add(GetSongsData(ref totalDuration, out int minDuration, out int maxDuration));
            Console.WriteLine($"Total: {totalDuration}, min: {minDuration}, max: {maxDuration}");

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

            var exampleSong1 = CreateSong();
            Console.WriteLine($"CreateDefaultSong: {exampleSong1.Duration}, {exampleSong1.Name}, " +
                $"{exampleSong1.Artist.Name}, {exampleSong1.Album.Name}");

            var exampleSong2 = CreateSong("First_Song");
            Console.WriteLine($"CreateNamedSong: {exampleSong2.Duration}, {exampleSong2.Name}, " +
                $"{exampleSong2.Artist.Name}, {exampleSong2.Album.Name}");

            var exampleSong3 = CreateSong(300, "Best_Song", new Album ("Hello", 2009), new Artist ("Light", "Pop"));
            Console.WriteLine($"CreateSong: {exampleSong3.Duration}, {exampleSong3.Name}, " +
                $"{exampleSong3.Artist.Name}, {exampleSong3.Album.Name}");

            player.Add(exampleSong1, exampleSong2, exampleSong3);

            var newArtist1 = AddArtist("Beyonce");
            Console.WriteLine($"\nNew Artist: {newArtist1.Name}");
            var newArtist2 = AddArtist();
            Console.WriteLine($"New Artist: {newArtist2.Name}");
            var newAlbum1 = AddAlbum("Sky", 2001);
            Console.WriteLine($"New Album: {newAlbum1.Name}, {newAlbum1.Year}");
            var newAlbum2 = AddAlbum("Sky");
            Console.WriteLine($"New Album: {newAlbum2.Name}, {newAlbum2.Year}");
            var newAlbum3 = AddAlbum();
            Console.WriteLine($"New Album: {newAlbum3.Name}, {newAlbum3.Year}");

            Console.ReadLine();
        }

        public static Song[] GetSongsData(ref int totalDuration, out int minDuration, out int maxDuration)
        {
            minDuration = 1000;
            maxDuration = 0;
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

            var songs = new Song[10];
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var song = new Song()
                {
                    Duration = random.Next(1000),
                    Name = $"New song {i}",
                    Album = album,
                    Artist = artist
                };
                songs[i] = song;

                totalDuration += song.Duration;
                if (song.Duration < minDuration)
                {
                    minDuration = song.Duration;
                }
                maxDuration = Math.Max(maxDuration, song.Duration);
            }
            return songs;
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
        public static Song CreateSong(string name) // или return CreateSong (name, 5) если бы было 2 входящих параметра
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

        public static Artist AddArtist(string name = "Unknown Artist")
        {
            return new Artist
            {
                Name = name
            };
        }

        public static Album AddAlbum(string name = "Unknown Album", int year = 0)
        {
            return new Album
            {
                Name = name,
                Year = year
            };
        }
    }
}
