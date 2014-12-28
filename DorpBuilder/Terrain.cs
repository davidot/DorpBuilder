using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DorpBuilder
{
    public abstract class Terrain
    {

        private int _id;

        public int ID {
            get {return _id;}
        }

        public Terrain(int id)
        {
            this._id = id;
        }

        public abstract Color getColor(int data);



    }
}
