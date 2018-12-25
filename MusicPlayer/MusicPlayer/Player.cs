using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Player
    {
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 300;

        private bool _locked;
        public bool Locked { get; set; }

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

        public Song[] Songs;

        public void VolumeUp()
        {
            Volume++;
            Console.WriteLine("Sound has been increased.");
        }

        public void VolumeDown()
        {
            Volume--;
            Console.WriteLine("Sound has been reduced.");
        }

        public void VolumeChange(int step)
        {
            Volume += step;
            Console.WriteLine($"Sound has been changed on {_volume}.");
        }

        public void Lock()
        {
            _locked = true;
            Console.WriteLine("The player was locked.");
        }

        public void Unlock()
        {
            _locked = false;
            Console.WriteLine("The player was unlocked.");
        }

        public void Play()
        {
            if (_locked != true)
            {
                _playing = true;
            }
            Console.WriteLine($"Player is playing: {Songs[0].Name}");
            Console.WriteLine($"Playing is: {_playing}");
        }

        public void Stop()
        {
            if (_locked != true)
            {
                _playing = false;
            }
            Console.WriteLine("Player was stopped");
            Console.WriteLine($"Playing is: {_playing}");
        }
    }
}
