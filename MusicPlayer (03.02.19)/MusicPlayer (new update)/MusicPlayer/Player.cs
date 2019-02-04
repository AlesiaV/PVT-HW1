using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;
using System.Xml.Serialization;
using System.IO;
using System.Media;

namespace MusicPlayer
{
    public class Player : GenericPlayer<Song>, IDisposable
    {
        private bool disposed = false;
        private SoundPlayer _player = new SoundPlayer();

        public Player(ISkin skin) : base(skin)
        {

        }

        //public Player()
        //{
        //}

        public override List<Song> Songs { get; set; } = new List<Song>();

        public override bool Play(bool loop = false)
        {
            if (_locked)
            {
                _skin.Render("The player was locked");
                return _playing;
            }
            else
            {
                if (loop)
                {
                    _skin.Clear();
                    _skin.Render($"Player is playing: {Songs[0].Name}, Duration is: {Songs[0].Duration}");
                }
                else
                {
                    _playing = true;
                    for (int i = 0; i < Songs.Count; i++)
                    {
                        _skin.Clear();
                        _skin.Render($"Player is playing: {Songs[i].Name}, Duration is: {Songs[i].Duration}");
                        //проигрывание песен
                        //using (System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer())
                        //{
                        //    soundPlayer.SoundLocation = Songs[i].Path;
                        //    soundPlayer.Play();
                        //}

                    }
                }
                return _playing;
            }
        }

        public override void SortByTitle()
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

        public override void ShowAllListSongs()
        {
            _skin.Clear();
            Console.WriteLine();
            foreach (var item in Songs)
            {
                SongNewShortName(item);
                _skin.Render($"Name of song: {item.Name}, Genre: {item.Genres}");
            }
        }

        public override void ShowAllListSongs(List<Song> songs)
        {
            _skin.Clear();
            Console.WriteLine();
            foreach (var item in songs)
            {
                SongNewShortName(item);
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

        public List<Song> FilterByGenre(params Artist.Genres[] genre)
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

        public void Clear()
        {
            Songs.Clear();
        }

        public void Load(string folderPath)  //принимает путь к папке
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            if (directoryInfo.Exists)
            {
                var songsFiles = directoryInfo.GetFiles("*.mp3");
                foreach (var file in songsFiles)
                {
                    var musicFile = TagLib.File.Create(file.FullName);

                    Artist artist = new Artist
                    {
                        Name = musicFile.Tag.JoinedPerformers,
                        Genre = musicFile.Tag.JoinedGenres
                    };

                    Album album = new Album
                    {
                        Name = musicFile.Tag.Album,
                        Year = (int)musicFile.Tag.Year
                    };

                    Song song = new Song
                    {
                        Name = musicFile.Tag.Title,
                        //Genres = musicFile.Tag.FirstGenre,
                        Duration = (int)musicFile.Properties.Duration.TotalSeconds,
                        Artist = artist,
                        Album = album

                    };
                    Songs.Add(song);
                    Console.WriteLine($@"Name song: {song.Name}. Artist: {song.Artist.Name}. Duration: {song.Duration}");
                }

            }

            else Console.WriteLine("Invalid path to files specified"); //указан неверный путь к файлам
        }

        public void SaveAsPlaylist(string name)
        {
            XmlSerializer serializer = new XmlSerializer(Songs.GetType());
            using (FileStream fs = new FileStream($"{name}.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, Songs);
            }
            Console.WriteLine("Playlist saved");
        }

        public void LoadPlaylist(string name)
        {
            XmlSerializer serializer = new XmlSerializer(Songs.GetType());
            if (File.Exists($"{name}.xml"))
            {
                using (FileStream fs = new FileStream($"{name}.xml", FileMode.OpenOrCreate))
                {
                    Songs = (List<Song>)serializer.Deserialize(fs);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _skin = null;
                }
                _player.Dispose();
                disposed = true;
            }
        }

        ~Player()
        {
            Dispose(false);
        }
    }
}
