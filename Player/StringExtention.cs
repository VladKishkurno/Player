using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public static class StringExtention
    {
        public static string CutString(this string str)
        {
            if (str.Length > 13)
            {
                str = str.Remove(13, str.Length - 13) + "...";
            }

            return str;
        }
    }
}
