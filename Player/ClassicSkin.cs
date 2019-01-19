using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    public class ClassicSkin : Skin
    {
        public override void NewScreen()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.WriteLine(text);
        }

    }
}
