using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;

namespace MusicPlayer
{
    public class Player : GenericPlayer<Song>
    {
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;

        private bool _locked;
        public bool Locked { get; set; }

        private ISkin _skin { get; }           //абстрактный класс Skin --> теперь интерфейс ISkin
        public Player(ISkin skin) : base(skin)
        {
           // this._skin = skin;
        }

        private bool _playing;
        public bool Playing
        {
            get
            {
                return _playing;
            }
        }

        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }

            private set
            {
                if (value < MIN_VOLUME)
                {
                    _volume = MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public List<Song> Songs { get; private set; } = new List<Song>(); //нужен ли new ?
       // public Song[] Songs { get; private set; }

        public void VolumeUp()
        {
            if (_locked==false) Volume++;
            //Console.WriteLine("Sound has been increased."); //звук был изменен, увеличен
            _skin.Render("Sound has been increased.");
        }

        public void VolumeDown()
        {
            if (_locked == false) Volume--;
            //Console.WriteLine("Sound has been reduced."); //звук был уменьшен
            _skin.Render("Sound has been reduced.");
        }

        public void VolumeChange(int step)
        {
            if (_locked == false) Volume += step;
            //Console.WriteLine($"Sound has been changed on {_volume}."); //звук был изменен на такое-то значение
            _skin.Render($"Sound has been changed on {_volume}.");
        }

        public void Lock()
        {
            _locked = true;
            //Console.WriteLine("The player was locked."); //плеер заблокирован
            _skin.Render("The player was locked.");
        }

        public void Unlock()
        {
            _locked = false;
            //Console.WriteLine("The player was unlocked."); //плеер разблокирован
            _skin.Render("The player was unlocked.");
        }

        public bool Play(bool loop = false)
        {
            if (_locked)
            {
                //Console.WriteLine("The player was locked");
                _skin.Render("The player was locked");
                return _playing;
            }
            else
            {
                if (loop)
                {
                    _skin.Clear();
                    //Console.WriteLine($"Player is playing: {Songs[0].Name}, Duration is: {Songs[0].Duration}");
                    _skin.Render($"Player is playing: {Songs[0].Name}, Duration is: {Songs[0].Duration}");
                }
                else
                {
                    _playing = true;
                    for (int i = 0; i < Songs.Count; i++)
                    {
                        _skin.Clear();
                        //Console.WriteLine($"Player is playing: {Songs[i].Name}, Duration is: {Songs[i].Duration}");
                        _skin.Render($"Player is playing: {Songs[i].Name}, Duration is: {Songs[i].Duration}");
                        //System.Threading.Thread.Sleep(100);
                    }
                }
                return _playing;
            }
        }

        public void Stop()
        {
            if (_locked == false)
            {
                _playing = false;
            }
            //Console.WriteLine("Player was stopped");
            //Console.WriteLine($"Playing is: {_playing}");
            _skin.Render($"Playing is: {_playing}");
        }

        public void Add(List<Song> songsArray)
        {
            Songs = songsArray;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < Songs.Count; i++)
            {
                var tmp = Songs[0];
                Songs.RemoveAt(0);
                Songs.Insert(rnd.Next(Songs.Count + 1), tmp);
            }
        }
        
        public void SortByTitle()
        {
            List<string> LocalList = new List<string>();

            foreach (var item in Songs)
            {
                LocalList.Add(item.Name);
            }

            LocalList.Sort();

            List<Song> NewSongs = new List<Song>();

            foreach (var item in LocalList)
            {
                foreach (var item2 in Songs)
                {
                    if (item == item2.Name)
                        NewSongs.Add(item2);
                }
            }
            Songs = NewSongs;
        }

        public void ShowAllListSongs()
        {
            _skin.Clear();
            Console.WriteLine();
            foreach (var item in Songs)
            {
                SongNewShortName(item);
                //Console.WriteLine($"Name of song: {item.Name}, Genre: {item.Genres}"); //показать список песен для проверки работы Сортировки и Перемешивания
                _skin.Render($"Name of song: {item.Name}, Genre: {item.Genres}");
            }
        }

        public void ShowAllListSongs(List<Song> songs)
        {
            _skin.Clear();
            Console.WriteLine();
            foreach (var item in songs)
            {
                SongNewShortName(item);
                //Console.WriteLine($"Name of song: {item.Name}, Genre: {item.Genres}"); //показать список песен для проверки работы Сортировки и Перемешивания
                _skin.Render($"Name of song: {item.Name}, Genre: {item.Genres}");
            }
        }

        private Song SongNewShortName(Song song)
        {
            const int LengthOfSongName = 10;

            Song tmpSong = song;
            tmpSong.Name = tmpSong.Name.ModifiedOfSongsName(LengthOfSongName);

            return tmpSong;
        }

        public List<Song> FilterByGenre(params Artist.Genres [] genre)
        {
            List<Song> newSongs = new List<Song>();
            foreach (var song in Songs)
            {
                foreach (var genreForFilter in genre)
                {
                    if (song.Genres == genreForFilter)
                    {
                        newSongs.Add(song);
                    }
                }
            }
            
            return newSongs;
        }
    }
}
