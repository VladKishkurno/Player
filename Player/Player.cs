using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer//.Domain
{
    class Player
    {
        public Skin Skin;
        private int _volume;
        //public Song[] Songarray { get; private set; }
        public List<Song> Songs { get; private set; } = new List<Song>();

        private bool _locked;

        private bool _playing;

        private const int MIN_VOLUME = 0;
        private const int MAX_VOLUME = 100;

        public Player(Skin skin)
        {
            this.Skin = skin;
        }
        public void Add(List<Song> songs)
        {
             if (Songs == null) Songs = new List<Song>();
             Songs.AddRange(songs);
        }

        public bool Playing
        {
            get
            {
                return _playing;
            }
        }
        public int Volume
        {
            get
            {
                return _volume;
            }
            private set
            {
                if (value < MIN_VOLUME) _volume = MIN_VOLUME;
                else if (value > MAX_VOLUME) _volume = MAX_VOLUME;
                else _volume = value;
            }
        }

        public void VolumeUp()
        {
            if (_locked != true)
            {
                Volume++;
                Skin.Render($"Volume is Up: {Volume}");
            }
            else Skin.Render($"Player is Locked");
        }

        public void VolumeDown()
        {
            if (_locked != true)
            {
                Volume--;
                Skin.Render($"Volume is Down: {Volume}");
            }
            else Skin.Render($"Player is Locked");
        }
        

        public void VolumeChage(int step)
        {
            if (_locked != true)
            {
                Volume += step;
                Skin.Render($"Volume is Change: {Volume}");
            }
            else Skin.Render($"Player is Locked");
        }

        public void Lock()
        {
            _locked = true;
            Skin.Render($"Player is locked ");
        }

        public void UnLock()
        {
            _locked = false;
            Skin.Render($"Player is Unlocked");
        }

        public void Play(bool loop)
        {
            if (_locked != true)
            {
                int numLoop = 0;
                _playing = true;
                //if (loop == false) numLoop = 1;
                //else numLoop = 5;
                numLoop = (loop == false) ? 1 : 5;

                Skin.NewScreen();
                for (int j = 0; j < numLoop; j++)
                {
                    foreach (var item 
                        in Songs)
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

                        
                        Skin.Render($"{item.Name.CutString()} , {item.Lirics}");
                        //Console.WriteLine($"Player is playing: {item.Name.CutString()} , {item.Lirics} ");
                        //item.PrintGanre();
                        
                        Console.ResetColor();
                    }                  
                }
                System.Threading.Thread.Sleep(2000);
            }
            else Skin.Render($"Player is Locked");
        }

        public void Stop()
        {
            if (_locked != true)
            {
                _playing = false;
                Console.WriteLine("Player is stoped");
            }
            else Console.WriteLine($"Player is Locked");
        }

        public void Shuffle()
        {
            Songs = this.Songs.Shuffle();
        }

        public  void SortByTitle()
        {
            this.Songs.Sort();
        }

        public void FilterByGenre(Ganre ganre)
        {
            var newSongCollection = new List<Song>();

            for (int i = 0; i < this.Songs.Count; i++)
            {
                if ((this.Songs[i].Ganre & ganre) != 0)
                {
                    newSongCollection.Add(this.Songs[i]);
                }

            }

            Songs = newSongCollection;

        }

    }
}
