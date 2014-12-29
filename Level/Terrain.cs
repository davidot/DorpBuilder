using DorpBuilder.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DorpBuilder.Level
{
    public abstract class Terrain
    {
        private static Dictionary<int, Terrain> terrains = new Dictionary<int, Terrain>();

        private static Terrain _nullTerrain;
        private static Terrain _dirt;

        public static Terrain NullTerrain {
            get { return _nullTerrain; }
        }

        public static Terrain Dirt
        {
            get { return _dirt; }
        }

        private static bool _init = false;

        public static void Init()
        {
            if (_init)
            {
                return;
            }
            _init = true;
            _nullTerrain = new DefualtTerrain(0,Color.Black);
            _dirt = new DefualtTerrain(1,new Color[]{Color.Brown,Color.RosyBrown});
        }


        private int _id;

        public int ID {
            get {return _id;}
        }

        public Terrain(int id)
        {
            if (terrains.ContainsKey(id))
            {
                throw new InvalidOperationException("Error already have a tile with this id");
            }
            this._id = id;
        }

        public abstract Color GetColor(int data);

        public static Terrain get(int id) {
            if (terrains.ContainsKey(id))
            {
                return terrains[id];
            }
            return NullTerrain;
        }


    }
}
