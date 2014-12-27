using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DorpBuilder
{
    class Level
    {

        private int _Width;

        public int Width
        {
            get { return this._Width; }
        }

        private int _Height;

        public int Height
        {
            get { return this._Height; }
        }


        public Level(int width, int height)
        {
            this._Width = width;
            this._Height = height;
        }

    }
}
