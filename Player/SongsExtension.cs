using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public static class SongsExtension
    {
        public static List<Song> Shuffle(this List<Song> songs)
        {
            var newSongCollection = new List<Song>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j < songs.Count;)
                {
                    newSongCollection.Add(songs[j]);
                    j += 3;
                }
            }
            
            return newSongCollection;
        }
    }
}
