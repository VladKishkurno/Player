using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    [Serializable]
    public class PlayerException: Exception
    {
        public PlayerException(string message) : base(message)
        {

        }
    }
}
