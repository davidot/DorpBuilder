using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DorpBuilder;
using Microsoft.Xna.Framework.Graphics;
using DorpBuilder.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
        int yScroll = 0;

        private int _zoom = 1;

        public int Zoom
        {
            get { return _zoom; }

            set
            {
                if(value < 1)
                    throw new InvalidOperationException("Cant set zoom to less than 1");
                int oldZoom = _zoom;
                int newZoom = value;
                xScroll = (xScroll / oldZoom) * newZoom;
                yScroll = (yScroll / oldZoom) * newZoom;
            }
        }

        public Level(int width, int height)
        {
            this._Width = width;
            this._Height = height;

            terrains = new int[2][,];
            for (int i = 0; i < terrains.Length; i++)
            {
                terrains[i] = new int[width, height];
            }

            Random rand = new Random();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    terrains[TerrainIndex][x, y] = (rand.Next(2) == 0 ? Terrain.NullTerrain : Terrain.Dirt).ID;
                    terrains[DataIndex][x, y] = rand.Next(2);
                }
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

        public int GetData(int x, int y)
        {
            if (InRange(x, y))
            {
                return terrains[DataIndex][x, y];
            }
            return 0;
        }

        public bool InRange(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return false;
            return true;
        }


        public Color GetColor(int x, int y)
        {
            return GetTerrain(x, y).GetColor(GetData(x, y));
        }


        public void Render(SpriteBatch spriteBatch,GraphicsDevice graphics, Size renderSize)
        {

            int terrainZoomSize = TerrainSize * Zoom;

            int renderWidth = renderSize.Width / terrainZoomSize;
            int renderHeight = renderSize.Height / terrainZoomSize;

            Texture2D texture = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            texture.SetData<Color>(new Color[] { Color.White });

            int firstXTile = (xScroll) / terrainZoomSize;
            int firstYTile = (yScroll) / terrainZoomSize;

            for (int x = firstXTile; x < firstXTile + renderWidth; x++)
            {
                for (int y = firstYTile; y < firstYTile + renderHeight; y++)
                {

                    spriteBatch.Draw(texture, new Rectangle((x - firstXTile) * terrainZoomSize, (y - firstYTile) * terrainZoomSize, terrainZoomSize, terrainZoomSize), GetColor(x, y));
                }
            }

        }

        public void Update(InputHandler handler)
        {
            if (handler.IsKeyDown(Keys.Left))
            {
                xScroll = Math.Max(0, xScroll - 1);
            }
            if (handler.IsKeyDown(Keys.Right))
            {
                xScroll = Math.Min(Width, xScroll + 1);
            }

            if (handler.IsKeyDown(Keys.Up))
            {
                yScroll = Math.Max(0, yScroll - 1);
            }
            if (handler.IsKeyDown(Keys.Down))
            {
                yScroll = Math.Min(Height, yScroll + 1);
            }

            int scrollWheel = handler.ScrollWheelDifference();

            if (scrollWheel > 0)
            {
                Zoom++;
            }
            if (scrollWheel < 0 && Zoom > 1)
            {
                Zoom--;
            }

        }

        public void Center(Point point, Size renderSize)
        {
            


        }
    }
}
