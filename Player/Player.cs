using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TagLib;
using TagLib.Mpeg;
using System.Media;

namespace MyPlayer//.Domain
{
    class Player : GenericPlayer<Song>, IDisposable
    {
        private SoundPlayer soundPlayer = new SoundPlayer();

        private bool disposed = false;
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
                    Skin = null;
                    Clear();  // удаляю playlist
                    Items = null; // удаляю ссылку на объект
                }
                soundPlayer?.Dispose();
                disposed = true;
            }
        }
        ~Player()
        {
            Dispose(false);
        }


        public Player(ISkin skin) : base(skin)
        {

        }

        public override void Play(bool loop)
        {
            if (Locked != true)
            {
                if (Items.Count == 0)
                {
                    Console.WriteLine("Выберите песни для воспроизведения");
                    return;
                }
                int numLoop = 0;

                numLoop = (loop == false) ? 1 : 5;

                Skin.NewScreen();
                for (int j = 0; j < numLoop; j++)
                {
                    foreach (var item in Items)
                    {

                        ViewPlayList(item);

                        soundPlayer.SoundLocation = item.Path;
                        soundPlayer.PlaySync();
                        soundPlayer.Play();

                        Console.ResetColor();
                    }
                }
                System.Threading.Thread.Sleep(2000);
            }
            else Skin.Render("Player is Locked");
        }

        public void FilterByGenre(Ganre ganre)
        {
            var newSongCollection = new List<Song>();

            for (int i = 0; i < this.Items.Count; i++)
            {
                if ((this.Items[i].Ganre & ganre) != 0)
                {
                    newSongCollection.Add(this.Items[i]);
                }

            }

            Items = newSongCollection;

        }

        public void Load(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            var files = dirInfo.GetFiles("*.wav");

            if (Items == null) Items = new List<Song>();

            foreach (var item in files)
            {
                //AudioFile audio = new AudioFile(item.FullName, ReadStyle.Average);
                SoundPlayer soundPlayer = new SoundPlayer(item.FullName);
                var artist = new Artist();// audio.Tag.FirstPerformer);
                var album = new Album();// audio.Tag.Album, audio.Tag.Year);

                Items.Add(new Song { Name = item.Name, Album = album, Artist = artist, /*Duration = audio.Properties.Duration.TotalMinutes*/ Path = item.FullName/*, Lirics = audio.Tag.Lyrics*/ }); 
            }
        }

        public void SaveAsPlaylist(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Items);
            }
        }

        public void LoadPlaylist(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Items = (List<Song>)formatter.Deserialize(fs);
            }
        }

        public void ViewPlayList(Song thisPlaySong)
        {
            Skin.NewScreen();

            foreach (var item in Items)
            {
                if (!item.IsLiked.HasValue)
                {
                    Console.ResetColor();
                }
                else if (item.IsLiked.Value == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                
                if(thisPlaySong == item)
                {
                    Skin.Render($"***{item.Name.CutString()}  {item.Artist.Name}***");
                }
                else
                {
                    Skin.Render($"{item.Name.CutString()}  {item.Artist.Name}");
                }

                Console.ResetColor();
            }
        }
    }
}
