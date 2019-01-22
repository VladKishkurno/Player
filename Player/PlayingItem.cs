using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public class PlayingItem : IComparable<PlayingItem>
    {
        public int Duration;
        public string Name;

        public int CompareTo(PlayingItem comparePart)
        {
            if (comparePart == null)
                return 1;

            else
                return this.Name.CompareTo(comparePart.Name);
        }
    }
}
