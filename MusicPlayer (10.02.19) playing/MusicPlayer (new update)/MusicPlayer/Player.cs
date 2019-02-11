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

        public Player()
        {

        }

        public Player(ISkin skin) : base(skin)
        {

        }

        public override List<Song> Songs { get; set; } = new List<Song>();

        public event Action<string> PlayerStartedEvent;
        public event Action<List<Song>, Song, bool, int> SongsListChangedEvent;
        public event Action<List<Song>, Song, bool, int> SongStartedEvent;
        public event Action<string> OnErrorEvent;
        public event Action<string> OnWarningEvent;

        public async Task Play()
        {
            if (!_locked && Songs.Count > 0)
            {
                _playing = true;
            }

            if (_playing == true)
            {
                PlayerStartedEvent?.Invoke("Player started");

                //_playing = true;
                //проигрывание песен

                await Task.Run(() =>
                {
                    try
                    {
                        foreach (var song in Songs)
                        {
                            try
                            {
                                SongStartedEvent?.Invoke(Songs, song, _locked, _volume);
                                using (SoundPlayer soundPlayer = new SoundPlayer())
                                {
                                    soundPlayer.SoundLocation = song.Path;
                                    soundPlayer.PlaySync();
                                    System.Threading.Thread.Sleep(10);
                                }
                            }

                            catch (FileNotFoundException ex)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                //OnErrorEvent($"Файл не найден (возможно файл был удален после загрузки песен в плеер)!{ex.Message}!");
                                throw new FailedToPlayException($"Ошибка проигрывания файла: ** {ex.Message} **");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                //OnErrorEvent($"Формат аудиофайла не поддерживается(возможно файл был переименован в mp3)\n!{ex.Message}!");
                                throw new FailedToPlayException($"Ошибка проигрывания файла: ** {ex.Message} **");
                            }
                        }
                    }
                    catch (FailedToPlayException ex)
                    {
                        _playing = false;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        OnWarningEvent(ex.Path);

                    }
                    catch (Exception ex)
                    {
                        _playing = false;
                        OnErrorEvent(ex.Message);
                    }
                });
            }
            //_playing = false;
        }

        public class PlayerException : Exception
        {
            public string Path { get; set; }
            public PlayerException()
            {

            }
        }

        public class FailedToPlayException : PlayerException
        {
            public FailedToPlayException() { }
            public FailedToPlayException(string messagePath)
            {
                this.Path = messagePath;
            }
            public FailedToPlayException(string message, string Path) : this(message)
            {
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
            SongsListChangedEvent?.Invoke(Songs, null, _locked, _volume);
        }

        public override void ShowAllListSongs()
        {
            //_skin.Clear();
            Console.WriteLine();
            foreach (var item in Songs)
            {
                SongNewShortName(item);
                //_skin.Render($"Name of song: {item.Name}, Genre: {item.Genres}");
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

        public void Load(string folderPath)  //принимает путь к папке с mp3
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
                SongsListChangedEvent?.Invoke(Songs, null, _locked, _volume);
            }

            else Console.WriteLine("Invalid path to files specified");//указан неверный путь к файлам
        }

        public void Load2(string source) //принимает путь к папке с wav
        {
            var dirInfo = new DirectoryInfo(source);

            if (dirInfo.Exists)
            {
                var files = dirInfo.GetFiles();
                foreach (var file in files)
                {
                    var song = new Song
                    {
                        Path = file.FullName,
                        Name = file.Name
                    };

                    Songs.Add(song);
                }
            }
            else Console.WriteLine("Invalid path to files specified");
            SongsListChangedEvent?.Invoke(Songs, null, _locked, _volume);
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
