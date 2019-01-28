using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;

namespace MusicPlayer
{
    public abstract class GenericPlayer<T> where T: PlayingItem
    {
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;

        protected bool _locked;
        public bool Locked { get; set; }

        protected ISkin _skin { get; }           //абстрактный класс Skin --> теперь интерфейс ISkin
        public GenericPlayer(ISkin skin)
        {
            this._skin = skin;
        }

        protected bool _playing;
        public bool Playing
        {
            get
            {
                return _playing;
            }
        }

        protected int _volume;
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

        public abstract List<T> Songs { get; set; } //нужен ли new ?

        public void VolumeUp()
        {
            if (_locked == false) Volume++;
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

        public abstract bool Play(bool loop = false);

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

        public void Add(List<T> songsArray)
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

        public abstract void SortByTitle();
        public abstract void ShowAllListSongs();
        public abstract void ShowAllListSongs(List<T> items);
    }
}
