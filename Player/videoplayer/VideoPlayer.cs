using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer.videoplayer
{
    public class VideoPlayer : GenericPlayer<Video>
    {
        public VideoPlayer(ISkin skin) : base(skin)
        {

        }

        public override void Play(bool loop)
        {
            if (Locked != true)
            {
                int numLoop = 0;
               
                numLoop = (loop == false) ? 1 : 5;

                Skin.NewScreen();
                for (int j = 0; j < numLoop; j++)
                {
                    foreach (var item
                        in Items)
                    {
                        Skin.Render(item.Name.CutString() + item.Path);

                        Console.ResetColor();
                    }
                }
                System.Threading.Thread.Sleep(2000);
            }
            else Skin.Render("Player is Locked");
        }
    }
}
