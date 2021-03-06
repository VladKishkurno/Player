﻿using System;
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
        public event Action<List<Song>, Song, bool, int, bool> SongsListChangedEvent;
        public event Action<List<Song>, Song, bool, int, bool> SongStartedEvent;
        public event Action<List<Song>, Song, bool, int, bool> PlayerStartedEvent;
        public event Action<string> OnError;
        public event Action<string> OnWarning;

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
                    Clear();
                    Items = null;
                }
                soundPlayer?.Dispose();
                disposed = true;
            }
        }

        ~Player()
        {
            Dispose(false);
        }


        //public Player(ISkin skin) : base(skin)
        //{

        //}

        public override Task<bool> Play(bool loop)
        {
           
                return Task.Run(() =>
                {
                    if (!Locked && Items.Count > 0)
                    {
                        Playing = true;
                        PlayerStartedEvent?.Invoke(Items, null, Locked, Volume, Playing);
                    }

                    if (Playing)
                    {
                        int numLoop = 0;

                        numLoop = (loop == false) ? 1 : 5;

                        //Skin.NewScreen();
                       
                            for (int j = 0; j < numLoop; j++)
                        {
                            foreach (var item in Items)
                            {
                                try
                                {
                                    ViewPlayList(item);

                                SongStartedEvent?.Invoke(Items, item, Locked, Volume, Playing);

                                soundPlayer.SoundLocation = item.Path;
                                soundPlayer.PlaySync();
                                    //soundPlayer.Play();
                                }
                                catch (FileNotFoundException)
                                {
                                    OnWarning?.Invoke("Файл не найден");
                                    throw new FailedToPlayException("Файл не найден", item.Path);
                                }
                                catch (InvalidOperationException)
                                {
                                    OnWarning?.Invoke("Проверте расширение файла");
                                    throw new System.Exception("Проверте расширение файла");
                                }
                                Console.ResetColor();
                            }
                        }
                        
                        Playing = false;
                        System.Threading.Thread.Sleep(2000);
                    }
                    return Playing;
                });
           
            //else Skin.Render("Player is Locked");
        }

        //private Task PlaySong(string path)
        //{
        //    return Task.Run(() =>
        //    {
                
        //    });
        //}

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

        public Task Load(string path)
        {
            return Task.Run(() =>
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
                    SongsListChangedEvent?.Invoke(Items, null, Locked, Volume, Playing);
                }
            });
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
            //Skin.NewScreen();

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
                    //Skin.Render($"***{item.Name.CutString()}  {item.Artist.Name}***");
                }
                else
                {
                    //Skin.Render($"{item.Name.CutString()}  {item.Artist.Name}");
                }

                Console.ResetColor();
            }
        }
    }
}
