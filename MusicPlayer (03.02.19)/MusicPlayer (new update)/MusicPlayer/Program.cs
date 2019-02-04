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
            using (Player player = new Player(new ColorSkin1(ConsoleColor.DarkMagenta)))
            {
                //Player player = new Player(new ColorSkin2());

                string folderPath = @"D:\Музыка\";
                player.Load(folderPath);
                player.Clear();
                player.SaveAsPlaylist(@"D:\Музыка\MusicList");
                player.LoadPlaylist(@"D:\Музыка\MusicList");

                //player.SortByTitle();
                //player.Play();
                player.ShowAllListSongs();

                //player.Volume = 20;
                //int totalDuration = 0;
                //layer.Add(GetSongsData(ref totalDuration, out int minDuration, out int maxDuration));

                //player.Shuffle();
                //player.Play();
                //player.ShowAllListSongs();

                /*player.Songs[0].LikeSong();
                player.Songs[1].DislikeSong();
                player.Songs[2].LikeSong();*/

                //for (int i = 0; i < player.Songs.Count; i++)
                //{
                //    Console.WriteLine(player.Songs[i].SetColoreOfSong());
                //}


                //Console.WriteLine("\nFilter by genres: Pop and PopRock");
                //player.ShowAllListSongs(player.FilterByGenre(Artist.Genres.Pop, Artist.Genres.Disco));

                Console.ReadLine();
            }
        }
    }
}

