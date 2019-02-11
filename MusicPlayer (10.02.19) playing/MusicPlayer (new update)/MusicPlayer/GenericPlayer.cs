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
        
        public event Action<string> PlayerStoppedEvent;
        private event Action<string> SongsListChangedEvent;
        public event Action<string> VolumeChangedEvent;
        public event Action<string> PlayerLockedEvent;
        public event Action<string> PlayerUnlockedEvent;

        protected ISkin _skin { get; set; }           //абстрактный класс Skin --> теперь интерфейс ISkin
        public GenericPlayer(ISkin skin)
        {
            this._skin = skin;
        }
        public GenericPlayer()
        {
            
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

        public abstract List<T> Songs { get; set; }

        public void VolumeUp()
        {
            if (_locked == false)
            {
                Volume++;
                VolumeChangedEvent?.Invoke("Volume changed");
            }
        }

        public void VolumeDown()
        {
            if (_locked == false)
            {
                Volume--;
                VolumeChangedEvent?.Invoke("Volume changed");
            }
        }

        public void VolumeChange(int step)
        {
            if (_locked == false)
            {
                Volume += step;
                VolumeChangedEvent?.Invoke("Volume changed");
            }
        }

        public void Lock()
        {
            _locked = true;
            PlayerLockedEvent?.Invoke("Player was Lock");
        }

        public void Unlock()
        {
            _locked = false;
            PlayerUnlockedEvent?.Invoke("Player was UnLock");
        }

        //public abstract bool Play(bool loop = false);

        public void Stop()
        {
            if (_locked == false)
            {
                _playing = false;
                PlayerStoppedEvent?.Invoke("Player was Stop");
            }
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
            SongsListChangedEvent?.Invoke("SongList changed");
        }

        public abstract void SortByTitle();
        public abstract void ShowAllListSongs();
        public abstract void ShowAllListSongs(List<T> items);
    }
}
