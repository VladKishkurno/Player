using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public class Song: IComparable<Song>
    {
        public int Duration;
        public string Name;
        public string Lirics;
        public Artist Artist;
        public Album Album;

        public Ganre Ganre;

        protected bool? _isLiked = null;
        
        public bool? IsLiked
        {
            get
            {
                return _isLiked;
            }
        }

        public void Like()
        {
            this._isLiked = true;
        }

        public void Dislike()
        {
            this._isLiked = false;
        }

        public int CompareTo(Song comparePart)
        {
            if (comparePart == null)
                return 1;

            else
                return this.Name.CompareTo(comparePart.Name);
        }
    }
}
