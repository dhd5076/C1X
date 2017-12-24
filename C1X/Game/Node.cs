using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace C1X.Game
{
    public abstract class Node
    {
        public Texture2D Texture2D{ get; private set;  }
        public Vector2 Position { get; private set; }

        public abstract void Update();
    
        private Guid GUID { get; }
        

        public Node()
        {
            this.GUID = genGuid();
        }

        public Node(Texture2D texture2D, Vector2 position)
        {
            this.Texture2D = texture2D;
            this.Position = position;
        }

        private Guid genGuid()
        {
            return Guid.NewGuid();
        }
    }
}
