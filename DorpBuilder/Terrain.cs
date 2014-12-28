using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DorpBuilder
{
    public abstract class Terrain
    {

        private ushort _id;

        public int ID {
            get {return _id;}
        }

        public Terrain(ushort id)
        {
            this._id = id;
        }

        public abstract ConsoleColor getColor();

    }
}
