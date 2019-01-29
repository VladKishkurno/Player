using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public class Artist /*: IDisposable*/
    {
        public string Name;
        public string Ganre;

        //~Artist()
        //{
        //    Dispose();
        //}
        //public void Dispose()
        //{
        //    Name = null;
        //    Ganre = null;
        //}

        public Artist()
        {
            this.Name = "No Name";
        }

        public Artist( string Name )
        {
            this.Name = Name;
        }

        public Artist(string name, string ganre)
        {
            this.Name = name;
            this.Ganre = ganre;
        }

    }


}
