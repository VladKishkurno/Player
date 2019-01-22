using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    class UpperSkin : ISkin
    {
        public void NewScreen()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            Console.WriteLine(text.ToUpper());
        }

    }
}
