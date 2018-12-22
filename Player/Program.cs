using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    class Program
    {
        public static Song[] GetSongsDate()
        {
            var artist = new Artist();
            var album = new Album();


            //artist.Name = "Sabaton";
            //artist.Ganre = "Rock";

            //var artist = new Artist();
            var artist2 = new Artist("Rammstain");
            var artist3 = new Artist("Rammstain", "Rock");

            Console.WriteLine(artist.Name);
            Console.WriteLine(artist2.Name);
            Console.WriteLine(artist3.Name + artist3.Ganre);

            album.name = "No";
            album.year = 2015;

            var song = new Song
            {
                Duration = 150,
                Name = "Sabaton",
                Album = album,
                Artist = artist
            };
            return new Song[] { song };
        }

        public static void TraceInfo( Player player)
        {
            Console.WriteLine(player.Songarray[0].Artist.Name);
            Console.WriteLine(player.Songarray[0].Duration);
            Console.WriteLine(player.Songarray.Length);
            Console.WriteLine(player.Volume);
        }

        static void Main(string[] args)
        {
            var player = new Player();
            //var song = new Song();

            

            // player.Play();

            // //player.Volume = 20;
             player.Songarray = GetSongsDate();



            // Console.WriteLine(player.Volume);
            // player.VolumeChage(300);
            // Console.WriteLine(player.Volume);

            // player.Stop();

            //// TraceInfo(player);

            Console.ReadKey();
        }
    }
}
