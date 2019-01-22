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
      public static List<Song> GetSongsDate( ref int totalDuration, out int maxDuration, out int minDuration )
        {
            var artist = new Artist();
            var album = new Album();

            minDuration = 1000;
            maxDuration = 0;

            var songs = new List<Song>();
            var random = new Random();
            var ganres = new List<Ganre> { Ganre.None};

            for (int i = 0; i < 10; i++)
            {
                songs.Add(new Song
                { Duration = random.Next(1000),
                    Name = $"New song {random.Next(0, 10)} agasgdfveqgvavsfvasc",
                    Lirics = $"New lirics {random.Next(0, 100)}",
                    Album = album,
                    Artist = artist,
                    Ganre = (Ganre)  0                });



                if (i == 5 || i == 9 || i == 3)
                {
                    songs[i].Like();
                    songs[i].Ganre = Ganre.Rock | Ganre.Afro;
                }

                if(i == 2 || i == 7 || i == 6)
                {
                    songs[i].Dislike();
                    songs[i].Ganre = Ganre.Jazz | Ganre.Folk;
                }

                if (i == 1 || i == 4 || i == 8)
                {
                    songs[i].Ganre = Ganre.Country | Ganre.Easy_listening | Ganre.Rock;
                }


                totalDuration += songs[i].Duration;
                if (songs[i].Duration < minDuration) minDuration = songs[i].Duration;
                maxDuration = Math.Max(maxDuration, songs[i].Duration);
            }

            return songs;
        }

        public static List<Video> GetVideoDate()
        {
            var videos = new List<Video>();
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                videos.Add(new Video
                {
                    Duration = random.Next(1000),
                    Name = ($"New video   {random.Next(0, 10)}   agasgdfveqgvavsfvasc"),
                    Path = ($"New path   {random.Next(0, 100)}"),
                }
                );

            }

            return videos;
        }

        public static void TraceInfo( Player player)
        {
            Console.WriteLine(player.Items[0].Artist.Name);
            Console.WriteLine(player.Items[0].Duration);
            Console.WriteLine(player.Items.Count);
            Console.WriteLine(player.Volume);
        }

        public static void PrintName(Player player)
        {
            foreach(var item in player.Items)
            Console.WriteLine($" {item.Name} , {item.Lirics}");
        }

        static Song CreateSong()
        {
            var NewSong = new Song();
            Random rand = new Random();

            NewSong.Duration = rand.Next(1, 100);
            NewSong.Name = "Default Name";

            NewSong.Album = new Album();
            NewSong.Artist = new Artist();

            return NewSong;



           // return new Song { Name = "default", Duration = 120 }; альтернативная запись 
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

        static Song CreateSong(string name)
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
            ISkin skin = new ClassicSkin();
            ISkin skin2 = new ColorSkin(ConsoleColor.Green);
            ISkin skin3 = new UpperSkin();
            ISkin skin4 = new ColorSkin(ConsoleColor.DarkMagenta);
            bool loop = false;
            
            var player = new Player(skin);
            var videoPlayer = new VideoPlayer(skin);



            var artist = new Artist();
            var album = new Album();
            List<Song> songs = new List<Song>();
            

            int totalDuration = 0;
            int maxDuration = 0;
            player.Add(GetSongsDate(ref totalDuration, out maxDuration, out int minDuration));

            Console.WriteLine("Skin 1");
            player.Play(loop);

            Console.WriteLine("Skin 2");
            player.Skin = skin2;
            player.Play(loop);
            player.Lock();
            System.Threading.Thread.Sleep(1000);
            player.UnLock();
            System.Threading.Thread.Sleep(1000);


            Console.WriteLine("Skin 3");
            player.Skin = skin3;
            player.Play(loop);

            Console.WriteLine("Skin 4");
            player.Skin = skin4;
            player.Play(loop);

            System.Threading.Thread.Sleep(1000);
            player.Shuffle();
            player.Play(loop);
            System.Threading.Thread.Sleep(1000);

            player.SortByTitle();
            player.Play(loop);
            System.Threading.Thread.Sleep(1000);

            player.FilterByGenre(Ganre.Rock);
            player.Play(loop);
            System.Threading.Thread.Sleep(1000);


            //video test


            videoPlayer.Add(GetVideoDate());

            Console.WriteLine("Skin 1");
            videoPlayer.Play(loop);

            Console.WriteLine("Skin 2");
            videoPlayer.Skin = skin2;
            videoPlayer.Play(loop);
            videoPlayer.Lock();
            System.Threading.Thread.Sleep(1000);
            videoPlayer.UnLock();
            System.Threading.Thread.Sleep(1000);


            Console.WriteLine("Skin 3");
            videoPlayer.Skin = skin3;
            videoPlayer.Play(loop);

            Console.WriteLine("Skin 4");
            videoPlayer.Skin = skin4;
            videoPlayer.Play(loop);

            System.Threading.Thread.Sleep(1000);
            videoPlayer.Shuffle();
            videoPlayer.Play(loop);
            System.Threading.Thread.Sleep(1000);

            videoPlayer.SortByTitle();
            videoPlayer.Play(loop);
            System.Threading.Thread.Sleep(1000);

            Console.ReadKey();
        }

        static void TestVolume(Player player)
        {
            bool loop =  false;
            int totalDuration = 0;
            int maxDuration = 0;
            player.Add(GetSongsDate(ref totalDuration, out maxDuration, out int minDuration));
            Console.WriteLine($"Total {totalDuration} {minDuration} {maxDuration}");
            player.VolumeUp();
            player.VolumeDown();
            player.VolumeChage(51);

            //Console.WriteLine(player.Playing);

            player.Lock();
            // player.VolumeUp();
            player.Stop();
            player.Play(loop);
            player.UnLock();

            //loop = true;
            player.Stop();
            player.Play(loop);
        }
    }


}
