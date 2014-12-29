using DorpBuilder.Base;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DorpBuilder.Level
{
    public abstract class Building
    {


        public abstract BuildingInstance CreateInstance();

        public abstract bool CanPlace(Level level, int x, int y);

        public abstract Texture2D GetBuildingTexture();

        public abstract Size GetSize();
    }
}
