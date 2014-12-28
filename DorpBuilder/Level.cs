using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DorpBuilder;

namespace DorpBuilder
{
    public class Level
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

        int[][,] terrains;


        public Level(int width, int height)
        {
            this._Width = width;
            this._Height = height;

            terrains = new int[2][,];
            for (int i = 0; i < terrains.Length; i++)
            {
                terrains[i] = new int[width, height];
            }
        }




    }
}
