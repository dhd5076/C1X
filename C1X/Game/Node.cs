using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace C1X.Game
{
    public abstract class Node
    {
        public Texture2D Texture2D{ get; set;  }

        public abstract void Update();
    
        private Guid GUID { get; }
        

        public Node()
        {
            this.GUID = genGuid();
        }

        private Guid genGuid()
        {
            return Guid.NewGuid();
        }
    }
}
