using System;
using System.Linq;
using System.Text;

namespace DorpBuilder.Base
{
    public class Size
    {

        public int Width
        {
            get;

            private set;
        }

        public int Height
        {
            get;

            private set;
        }

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

    }
}
