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
            Console.WriteLine($"{artist3.Name}   {artist3.Ganre}");

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

        static Song CreateDefaultSong()
        {
            var NewSong = new Song();
            Random rand = new Random();

            NewSong.Duration = rand.Next(1, 100);
            NewSong.Name = "Default Name";

            NewSong.Album = new Album();
            NewSong.Artist = new Artist();

            return NewSong;
        }

        //static void CreateSAA()
        //{
        //    Song[] songs = new Song[5];
        //    Artist[] artists = new Artist[5];
        //    Album[] albums = new Album[5];

        //   for(int i = 0; i < 4; i++)
        //    {
                
        //    }

        //}

        static Song CreateNamedSong(string name)
        {
            var NewSong = new Song();
            Random rand = new Random();

            NewSong.Duration = rand.Next(100, 200);
            NewSong.Name = name;

            NewSong.Album = new Album();
            NewSong.Artist = new Artist();

            return NewSong;
        }

        static Song CreatSong(string name, int duration, Album album, Artist artist)
        {
            var NewSong = new Song();

            NewSong.Duration = duration;
            NewSong.Name = name;

            NewSong.Album = album;
            NewSong.Artist = artist;

            return NewSong;
        }

        static void Main(string[] args)
        {
            var player = new Player();

            TestVolume(player); // недостающая домашка

            var artist = new Artist();
            var album = new Album();

            Song song1, song2, song3;

            song1 = CreateDefaultSong();
            Console.WriteLine($"\nName : {song1.Name} \nDuration : {song1.Duration} \nArtist :{song1.Artist.Name} \nAlbum : {song1.Album.name}");
            song2 = CreateNamedSong("Named song");
            Console.WriteLine($"\nName : {song2.Name} \nDuration : {song2.Duration} \nArtist : {song2.Artist.Name} \nAlbum : {song2.Album.name}");
            song3 = CreatSong("Named song 2", 123, album, artist);
            Console.WriteLine($"\nName : {song3.Name} \nDuration : {song3.Duration} \nArtist : {song3.Artist.Name} \nAlbum : {song3.Album.name}");

           // CreateSAA();
            //var song = new Song();

            //// player.Play();
            //Console.WriteLine(player.Volume);
            //// //player.Volume = 20;

            // player.Play();
            // player.VolumeUp(player);
            //Console.WriteLine(player.Volume);
            //// Console.WriteLine(player.Volume);
            //player.VolumeChage(300);
            // Console.WriteLine(player.Volume);
            // player.Stop();
            ////// TraceInfo(player);



            //player.Playing = false;


            Console.ReadKey();
        }

        static void TestVolume(Player player)
        {
            player.Songarray = GetSongsDate();

            player.VolumeUp(player);
            player.VolumeDown(player);
            player.VolumeChage(51);

            //Console.WriteLine(player.Playing);

            player.Lock(player);
            player.Stop(player);
            player.Play(player);
            player.UnLock(player);

            player.Stop(player);
            player.Play(player);
        }
    }


}
