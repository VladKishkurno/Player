﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public abstract class GenericPlayer<T>
    {
        public event Action<List<T>, bool, int, bool> VolumeChangeEvent;
        public event Action<List<T>, bool, int, bool> PlayerLockedEvent;
        public event Action<List<T>, bool, int, bool> PlayerUnlockedEvent;
        
        public event Action<List<T>, bool, int, bool> PlayerStoppedEvent;
        //public ISkin Skin;
        private int _volume;
        //public Song[] Songarray { get; private set; }
        public List<T> Items { get; protected set; }

        private bool _locked;

        private bool _playing;

        private const int MIN_VOLUME = 0;
        private const int MAX_VOLUME = 100;

        //protected GenericPlayer(ISkin skin)
        //{
        //    this.Skin = skin;
        //}

        //public void Add(List<T> items)
        //{
        //    if (Items == null) Items = new List<T>();
        //    Items.AddRange(items);
        //}

        public void Clear()
        {
           Items?.RemoveRange(0, Items.Count);
        }


        public bool Locked
        {
            get
            {
                return _locked;
            }
        }

        public bool Playing
        {
            get
            {
                return _playing;
            }

            protected set
            {
                _playing = value;
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
                //Skin.Render($"Volume is Up:   {Volume}");
                VolumeChangeEvent?.Invoke(Items, _locked, _volume, _playing);
                //SongStartedEvent?.Invoke(Items, item, Locked, Volume);
            }
            //else Skin.Render("Player is Locked");
        }

        public void VolumeDown()
        {
            if (_locked != true)
            {
                Volume--;
                //Skin.Render($"Volume is Down:  {Volume}");
                VolumeChangeEvent?.Invoke(Items, _locked, _volume, _playing);
            }
            //else Skin.Render("Player is Locked");
        }


        public void VolumeChage(int step)
        {
            if (_locked != true)
            {
                Volume += step;
                // Skin.Render("Volume is Change:  {Volume}");
                VolumeChangeEvent?.Invoke(Items, _locked, _volume, _playing);
            }
           // else Skin.Render("Player is Locked");
        }

        public void Lock()
        {
            _locked = true;
            PlayerLockedEvent?.Invoke(Items, _locked, _volume, _playing);
            // Skin.Render("Player is locked ");
        }

        public void UnLock()
        {
            _locked = false;
            PlayerUnlockedEvent?.Invoke(Items, _locked, _volume, _playing);
            // Skin.Render("Player is Unlocked");
        }

        public abstract Task<bool> Play(bool loop);

        public void Stop()
        {
            if (_locked != true)
            {
                _playing = false;
                PlayerStoppedEvent?.Invoke(Items, _locked, _volume, _playing);
                //Console.WriteLine("Player is stoped");
            }
            //else Console.WriteLine("Player is Locked");
        }

        public void Shuffle()
        {
            Items = this.Items.Shuffle();
        }

        public void SortByTitle()
        {
            this.Items.Sort();
        }

    }
}
