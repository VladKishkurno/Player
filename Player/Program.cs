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
            bool loop = false;

            using (var player = new Player())
            {
                player.SongStartedEvent += ShowInfo;
                player.SongsListChangedEvent += ShowInfo;
                player.PlayerLockedEvent += Show;
                player.PlayerUnlockedEvent += Show;
                player.PlayerStoppedEvent += Show;
                player.PlayerStartedEvent += ShowInfo;
                player.VolumeChangeEvent += Show;
                player.OnError += Error;
                player.OnWarning += Error;
                var artist = new Artist();
                var album = new Album();
                List<Song> songs = new List<Song>();

                //player.Clear();

                string path = $@"D:\Download\[sound effects] Sega MegaDrive SFX - 316 Game Samples\Mortal Kombat";
                

                //string pathXML = "C://Users/User/Desktop/Player/Player/Player.xml";

                //player.SaveAsPlaylist(pathXML);
                PlaySong(player, loop, path);

                //player.VolumeUp();
                //PlaySong(player, loop, path);
                //player.Lock();
                ////player.Play(loop);
                //player.UnLock();
            }

            Console.ReadKey();
        }

        private static async void PlaySong(Player player, bool loop, string path)
        {
            await player.Load(path);
            await player.Play(loop);          
        }

        private static void Show(List<Song> songs, bool locked, int volume, bool playing)
        {
            ShowInfo(songs, null, locked, volume, playing);
        }
        private static void ShowInfo(List<Song> songs, Song playingSong, bool locked, int volume, bool playing)
        {  
            Console.Clear();// remove old data
            //Render the list of songs
            foreach (var song in songs)
                {
                    if (playingSong == song)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(song.Name);//Render current song in other color.
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            //Render status bar
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Volume is: {volume}. Locked: {locked}. Player is play: {playing}");
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }


}
