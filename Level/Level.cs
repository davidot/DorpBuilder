using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DorpBuilder;
using Microsoft.Xna.Framework.Graphics;
using DorpBuilder.Base;

namespace DorpBuilder.Level
{
    public class Level
    {

        public const int TerrainSize = 4;

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


        public const int TerrainIndex = 0;
        public const int DataIndex = 1;

        int xScroll = 0;
        int yScroll = 1;

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

        public Terrain GetTerrain(int x, int y)
        {
            if (InRange(x, y))
            {
                return Terrain.get(terrains[TerrainIndex][x, y]);
            }
            return Terrain.NullTerrain;
        }

        public bool InRange(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return false;
            return true;
        }






        public void Render(SpriteBatch spriteBatch, Size renderSize)
        {
            



        }
    }
}
