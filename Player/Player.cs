using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer//.Domain
{
    class Player : GenericPlayer<Song>
    {
        public Player(ISkin skin) : base(skin)
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
                    foreach (var item in Items)
                    {
                        if (!item.IsLiked.HasValue)
                        {
                            Console.ResetColor();
                        }
                        else if (item.IsLiked.Value == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Skin.Render(item.Name.CutString() + item.Lirics);

                        Console.ResetColor();
                    }
                }
                System.Threading.Thread.Sleep(2000);
            }
            else Skin.Render("Player is Locked");
        }

        public void FilterByGenre(Ganre ganre)
        {
            var newSongCollection = new List<Song>();

            for (int i = 0; i < this.Items.Count; i++)
            {
                if ((this.Items[i].Ganre & ganre) != 0)
                {
                    newSongCollection.Add(this.Items[i]);
                }

            }

            Items = newSongCollection;

        }



    }
}
