using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlayer.videoplayer;

namespace MyPlayer
{
    class Program
    {


        static void Main(string[] args)
        {
            ISkin skin = new ClassicSkin();
            ISkin skin2 = new ColorSkin(ConsoleColor.Green);
            ISkin skin3 = new UpperSkin();
            ISkin skin4 = new ColorSkin(ConsoleColor.DarkMagenta);
            bool loop = false;

            using (var player = new Player(skin))
            {
                var artist = new Artist();
                var album = new Album();
                List<Song> songs = new List<Song>();

                //player.Clear();

                string path = $@"D:\Download\[sound effects] Sega MegaDrive SFX - 316 Game Samples\Mortal Kombat";
                player.Load(path);

                string pathXML = "C://Users/User/Desktop/Player/Player/Player.xml";

                player.SaveAsPlaylist(pathXML);
                //player.Clear();
                //player.LoadPlaylist(pathXML);
                player.Play(loop);

                //string pathXML2 = "C://Users/User/Desktop/Player/Player/MyPlayer.xml";
                //player.Shuffle();
                //player.SaveAsPlaylist(pathXML2);
                //player.Clear();
                //player.Play(loop);
                //player.LoadPlaylist(pathXML2);
                //player.Play(loop);
            }
            //Console.WriteLine("Skin 1");
            //player.Play(loop);

            //Console.WriteLine("Skin 2");
            //player.Skin = skin2;
            //player.Play(loop);
            //player.Lock();
            //System.Threading.Thread.Sleep(1000);
            //player.UnLock();
            //System.Threading.Thread.Sleep(1000);


            //Console.WriteLine("Skin 3");
            //player.Skin = skin3;
            //player.Play(loop);

            //Console.WriteLine("Skin 4");
            //player.Skin = skin4;
            //player.Play(loop);

            //System.Threading.Thread.Sleep(1000);
            //player.Shuffle();
            //player.Play(loop);
            //System.Threading.Thread.Sleep(1000);

            //player.SortByTitle();
            //player.Play(loop);
            //System.Threading.Thread.Sleep(1000);

            //player.FilterByGenre(Ganre.Rock);
            //player.Play(loop);
            //System.Threading.Thread.Sleep(1000);

            Console.ReadKey();
        }

        
    }


}
