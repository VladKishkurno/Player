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

        public bool Locked;

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
            Volume ++;
            Console.WriteLine($"Volume is Up: {Volume}");
        }

        public void VolumeDown()
        {
            Volume --;
            Console.WriteLine($"Volume is Down: {Volume}");
        }

        public void VolumeChage(int step)
        {
            Volume += step;
            Console.WriteLine($"Volume is Change: {Volume}");
        }

        public void Lock()
        {
            Locked = true;
            Console.WriteLine($"Player is locked: ");
        }

        public void UnLock()
        {
            Locked = false;
            Console.WriteLine($"Player is UnLocked:");
        }

        public void Play()
        {
            if (Locked != true)
            {
                _playing = true;
                Console.WriteLine($"Player is playing: {Songarray[0].Name} ");
            }
            else Console.WriteLine($"Player is Locked");
        }

        public void Stop()
        {
            if (Locked != true)
            {
                _playing = false;
                Console.WriteLine("Player is stoped");
            }
            else Console.WriteLine($"Player is Locked");
        }


    }
}
