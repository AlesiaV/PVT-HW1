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
            //Player player = new Player(new ColorSkin1(ConsoleColor.DarkMagenta)); @"D:\Музыка\WAV-Short\";

            using (Player player = new Player())
            {
                string folderPath = @"D:\Музыка\";
                player.Load2(folderPath);

                player.OnErrorEvent += Show;
                player.OnWarningEvent += Show;
                player.PlayerStartedEvent += Show;
                player.SongStartedEvent += ShowInfo;
                player.SongsListChangedEvent += ShowInfo;
                player.PlayerStoppedEvent += Show;
                player.PlayerLockedEvent += Show;

                Visualizer(player);

                //player.Play();
                //player.VolumeUp();
                //player.VolumeChange(20);

                //player.Play();
                //player.Lock();

                //player.Play();
                //player.Unlock();

                //player.Clear();
                //player.SaveAsPlaylist(@"D:\Музыка\MusicList");
                //player.LoadPlaylist(@"D:\Музыка\MusicList");

                //player.SortByTitle();
                //player.Play();
                //player.ShowAllListSongs();

                Console.ReadLine();
            }
        }

        private static async void Visualizer(Player player)
        {
            Console.WriteLine("Please, enter the command to control the player:");
            Console.WriteLine("1 - Play, 2 - Stop, 3 - LoadPlaylist, 4 - LoadFolder.\n->");
            while (true)
            {
                string asyncCommands = Console.ReadLine();
                switch (asyncCommands)
                {
                    case "1":
                        await player.Play();
                        break;
                    case "2":
                        player.Stop();
                        break;
                    case "3":
                        player.LoadPlaylist(@"D:\Музыка\MusicList.xml");
                        break;
                    case "4":
                        player.Load2(@"D:\Музыка\WAV-Short\");
                        break;
                }
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

