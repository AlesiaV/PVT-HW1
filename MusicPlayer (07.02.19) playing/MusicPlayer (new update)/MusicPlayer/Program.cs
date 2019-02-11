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
            //Player player = new Player();
            //Player player = new Player(new ClassicSkin());
            //Player player = new Player(new ColorSkin1(ConsoleColor.DarkMagenta));

            using (Player player = new Player())
            {
                string folderPath = @"D:\Музыка\WAV-Short\";
                player.Load2(folderPath);

                player.PlayerStartedEvent += Show;
                player.SongStartedEvent += ShowInfo;
                player.SongsListChangedEvent += ShowInfo;
                player.PlayerStoppedEvent += Show;
                player.PlayerLockedEvent += Show;

                player.Play();
                player.VolumeUp();
                player.VolumeChange(20);

                player.Play();
                player.Lock();

                player.Play();
                player.Unlock();

                //player.Clear();
                //player.SaveAsPlaylist(@"D:\Музыка\MusicList");
                //player.LoadPlaylist(@"D:\Музыка\MusicList");

                //player.SortByTitle();
                //player.Play();
                player.ShowAllListSongs();

                Console.ReadLine();
            }
        }
        private static void ShowInfo(List<Song> songs, Song playingSong, bool locked, int volume)
        {
            Console.Clear();// remove old data

            //Render the list of songs
            foreach (var song in songs)
            {
                if (playingSong == song)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    //Console.WriteLine(song.Artist.Name + " - " + song.Name);   //для mp3
                    Console.WriteLine(song.Name);
                    Console.ResetColor();
                }
                else
                {
                    //Console.WriteLine(song.Artist.Name + " - " + song.Name);   //для mp3
                    Console.WriteLine(song.Name);
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Volume is: {volume}. Locked: {locked}");
            Console.ResetColor();
        }

        private static void Show(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}

