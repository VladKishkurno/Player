using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public static class SongsExtension
    {
        public static List<T> Shuffle<T>(this List<T> items)
        {
            List<T> newCollection = new List<T>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j < items.Count;)
                {
                    newCollection.Add(items[j]);
                    j += 3;
                }
            }

            return newCollection;
        }
    }
}
