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

       public void VolumeUp( Player player)
        {
            player.Volume ++;
            Console.WriteLine($"Volume is Up: {player.Volume}");
        }

        public void VolumeDown(Player player)
        {
            player.Volume --;
            Console.WriteLine($"Volume is Down: {player.Volume}");
        }

        public void VolumeChage(int step)
        {
            Volume += step;
            Console.WriteLine($"Volume is Change: {Volume}");
        }

        //public void Lock( Player player)
        //{
        //    player.Playing = false;
        //    Console.WriteLine($"Player is locked: {player.Playing}");
        //}

        //public void UnLock( Player player) 
        //{
        //    player.Playing = true;
        //    Console.WriteLine($"Player is UnLocked: {player.Playing}");
        //}

        public void Play()
        {
            Console.WriteLine($"Player is playing: {Songarray[0].Name} ");
        }

        public void Stop()
        {
            Console.WriteLine("Player is stoped");
        }


    }
}
