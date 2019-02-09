using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayer
{
    [Serializable]
    public class FailedToPlayException : PlayerException
    {
        string path;
        public FailedToPlayException(string message, string path) : base(message)
        {
            this.path = path;
        }
    }
}
