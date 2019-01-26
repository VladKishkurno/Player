using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
  public  class Album
    {
       public byte[] thumbnail;
       public string name;
       public uint year;

        public Album ()
        {
            this.name = "DefaultName";
        }

        public Album ( string name, uint year)
        {
            this.name = name;
            this.year = year;
        }
    }
}
