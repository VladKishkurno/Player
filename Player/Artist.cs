using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public class Artist
    {
        public string Name;
        public string Ganre;


        public Artist()
        { }

        public Artist( string Name )
        {
            this.Name = Name;
        }

        public Artist(string name, string ganre)
        {
            this.Name = name;
            this.Ganre = ganre;
        }

        ~ Artist() { }
    }


}
