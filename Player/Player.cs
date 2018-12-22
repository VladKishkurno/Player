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

        private const int MIN_VOLUME = 0;
        private const int MAX_VOLUME = 100;

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
        }

        public void VolumeDown(Player player)
        {
            player.Volume --;
        }

        public void VolumeChage(int step)
        {
            Volume += step;
        }

        void Lock()
        { }

        void UnLock()
        { }

        public void Play()
        {
            Console.WriteLine("Player is playing ");
        }

        public void Stop()
        {
            Console.WriteLine("Player is stoped");
        }


    }
}
