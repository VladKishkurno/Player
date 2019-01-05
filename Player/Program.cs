using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //artist.Name = "Sabaton";
            //artist.Ganre = "Rock";

            //var artist = new Artist();
            //var artist2 = new Artist("Rammstain");
            //var artist3 = new Artist("Rammstain", "Rock");

            //Console.WriteLine(artist.Name);
            //Console.WriteLine(artist2.Name);
            //Console.WriteLine($"{artist3.Name}   {artist3.Ganre}");

            //album.name = "No";
            //album.year = 2015;

            //var songs = new Song[10];

            //var random = new Random();


            //for (int i = 0; i < 10; i++)
            //{
            //    var song = new Song
            //    {
            //        Duration = random.Next(1000),
            //        Name = $"New song {i}",
            //        Album = album,
            //        Artist = artist
            //    };
            //    songs[i] = song;
            //    totalDuration += song.Duration;
            //    if (song.Duration < minDuration) minDuration = song.Duration;
            //    maxDuration = Math.Max(maxDuration, song.Duration);
            //}
            var songs = new List<Song>();
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                songs.Add(new Song
                { Duration = random.Next(1000),
                    Name = $"New song {random.Next(0, 10)}",
                    Lirics = $"New lirics {random.Next(0, 100)}",
                    Album = album,
                    Artist = artist,
                    Ganre = Ganre.None
                });
                if (i == 5 || i == 9)
                {
                    songs[i].Like();
                    //songs[i].Ganre = Ganre.Rock | Ganre.Afro;
                }

                if(i == 2 || i == 7)
                {
                    songs[i].Dislike();
                }

                totalDuration += songs[i].Duration;
                if (songs[i].Duration < minDuration) minDuration = songs[i].Duration;
                maxDuration = Math.Max(maxDuration, songs[i].Duration);
            }

            return songs;
        }

        public static void TraceInfo( Player player)
        {
            Console.WriteLine(player.Songs[0].Artist.Name);
            Console.WriteLine(player.Songs[0].Duration);
            Console.WriteLine(player.Songs.Count);
            Console.WriteLine(player.Volume);
        }

        public static void PrintName(Player player)
        {
            foreach(var item in player.Songs)
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
            bool loop = false;
            var player = new Player();

           

            var artist = new Artist();
            var album = new Album();
            List<Song> songs = new List<Song>();
            
            //songs.Add(CreateSong());
           // songs.Add(CreateSong("Named song"));
           // songs.Add(CreatSong("Named song 2", 123, album, artist));

            //player.Add(songs);

            //TestVolume(player); // 
            int totalDuration = 0;
            int maxDuration = 0;
            player.Add(GetSongsDate(ref totalDuration, out maxDuration, out int minDuration));

            Console.WriteLine("Что было создано");
            player.Play(loop);


            Console.WriteLine("Отсортированный");
            player.SortByTitle();
            //player.Add(SortByTitle(player));
            Console.WriteLine();
            //PrintName(player);
            player.Play(loop);


            Console.WriteLine("После перемешивания");
            //player.Add(Shuffle(player));
            player.Shuffle();

            player.Play(loop);

            //PrintName(player);

            //player.Add(SortByTitle(player));

           // player.Play(loop);
            //PrintName(player);
            //song1 = CreateSong();
            //Console.WriteLine($"\nName : {song1.Name} \nDuration : {song1.Duration} \nArtist :{song1.Artist.Name} \nAlbum : {song1.Album.name}");
            //song2 = CreateSong("Named song");
            //Console.WriteLine($"\nName : {song2.Name} \nDuration : {song2.Duration} \nArtist : {song2.Artist.Name} \nAlbum : {song2.Album.name}");
            //song3 = CreatSong("Named song 2", 123, album, artist);
            //song3.Lirics = "Lirics";
            //Console.WriteLine($"\nName : {song3.Name} \nDuration : {song3.Duration} \nArtist : {song3.Artist.Name} \nAlbum : {song3.Album.name}");



            //player.Add(song1);
            //player.Add(song1, song2);
            //player.Add(song1, song2, song3);
            //player.Play();
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
