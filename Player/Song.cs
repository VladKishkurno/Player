using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public class Song : PlayingItem
    {
        public string Lirics;
        public Artist Artist;
        public Album Album;

        public Ganre Ganre;

        protected bool? _isLiked = null;

        //public void Add(List<Ganre> ganres)
        //{
        //    if (Ganres == null) Ganres = new List<Ganre>();
        //    Ganres.AddRange(ganres);
        //}
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

        public void PrintGanre()
        {
            Ganre ganre = this.Ganre;

            Console.WriteLine("Жанр музыки");
            if ((ganre & Ganre.Afro) == Ganre.Afro)
            {
                Console.WriteLine(Ganre.Afro);
            }
            if ((ganre & Ganre.Avant_garde) == Ganre.Avant_garde)
            {
                Console.WriteLine(Ganre.Avant_garde);
            }
            if ((ganre & Ganre.Blues) == Ganre.Blues)
            {
                Console.WriteLine(Ganre.Blues);
            }
            if ((ganre & Ganre.Caribbean) == Ganre.Caribbean)
            {
                Console.WriteLine(Ganre.Caribbean);
            }
            if ((ganre & Ganre.Comedy) == Ganre.Comedy)
            {
                Console.WriteLine(Ganre.Comedy);
            }
            if ((ganre & Ganre.Country) == Ganre.Country)
            {
                Console.WriteLine(Ganre.Country);
            }
            if ((ganre & Ganre.Easy_listening) == Ganre.Easy_listening)
            {
                Console.WriteLine(Ganre.Easy_listening);
            }
            if ((ganre & Ganre.Electronic) == Ganre.Electronic)
            {
                Console.WriteLine(Ganre.Electronic);
            }
            if ((ganre & Ganre.Folk) == Ganre.Folk)
            {
                Console.WriteLine(Ganre.Folk);
            }
            if ((ganre & Ganre.Hip_hop) == Ganre.Hip_hop)
            {
                Console.WriteLine(Ganre.Hip_hop);
            }
            if ((ganre & Ganre.Jazz) == Ganre.Jazz)
            {
                Console.WriteLine(Ganre.Jazz);
            }
            if ((ganre & Ganre.Latin) == Ganre.Latin)
            {
                Console.WriteLine(Ganre.Latin);
            }
            if ((ganre & Ganre.Pop) == Ganre.Pop)
            {
                Console.WriteLine(Ganre.Pop);
            }
            if ((ganre & Ganre.Soul) == Ganre.Soul)
            {
                Console.WriteLine(Ganre.Soul);
            }
            if ((ganre & Ganre.Rock) == Ganre.Rock)
            {
                Console.WriteLine(Ganre.Rock);
            }
            if ((ganre | Ganre.None) == Ganre.None)
            {
                Console.WriteLine(Ganre.None);
            }
            // Console.WriteLine();

            //if (ganre == Ganre.None)  // Алтернативный вариант вывода жанров, рабочий
            //{
            //    Console.WriteLine(Ganre.None);
            //    return;
            //}

            //int b = 1;

            //for (int i = 0; i < 15; i++)
            //{
            //    Ganre r = (Ganre)((int)ganre & b);

            //    if (Ganre.HasFlag(r) && r != Ganre.None)
            //        Console.WriteLine((Ganre)b);

            //    b = b << 1;
            //}

        }
    }
}
