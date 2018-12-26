using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer//.Domain
{
    class Player
    {
        private int _volume;
        public Song[] Songarray;

        private bool _locked;

        private bool _playing;

        private const int MIN_VOLUME = 0;
        private const int MAX_VOLUME = 100;

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
                Console.WriteLine($"Volume is Up: {Volume}");
            }
            else Console.WriteLine($"Player is Locked");
        }

        public void VolumeDown()
        {
            if (_locked != true)
            {
                Volume--;
                Console.WriteLine($"Volume is Down: {Volume}");
            }
            else Console.WriteLine($"Player is Locked");
        }
        

        public void VolumeChage(int step)
        {
            if (_locked != true)
            {
                Volume += step;
                Console.WriteLine($"Volume is Change: {Volume}");
            }
            else Console.WriteLine($"Player is Locked");
        }

        public void Lock()
        {
            _locked = true;
            Console.WriteLine($"Player is locked ");
        }

        public void UnLock()
        {
            _locked = false;
            Console.WriteLine($"Player is Unlocked");
        }

        public void Play()
        {
            if (_locked != true)
            {
                _playing = true;
                Console.WriteLine($"Player is playing: {Songarray[0].Name} ");
            }
            else Console.WriteLine($"Player is Locked");
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


    }
}
