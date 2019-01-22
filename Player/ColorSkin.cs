using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    class ColorSkin : ISkin
    {
        private ConsoleColor _color;

        public ColorSkin(ConsoleColor Color)
        {
            _color = Color;
        }
        public void NewScreen()
        {
            Console.Clear();
        }



        public void Render(string text)
        {
            if (Console.ForegroundColor == _color && Console.ForegroundColor == ConsoleColor.Red)  // это меняет цвет текста, когда цвет фона 
            {                                                                                     //совпадает с цветом отображения Like DisLike
                Console.ForegroundColor = ConsoleColor.DarkBlue;                                 
                Console.WriteLine(text);
            }
            else if (Console.ForegroundColor == _color && Console.ForegroundColor == ConsoleColor.Green)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(text);
            }
            else if (Console.ForegroundColor == ConsoleColor.Green || Console.ForegroundColor == ConsoleColor.Red)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(text);
                
            }
            Console.ResetColor();
        }

    }
}
