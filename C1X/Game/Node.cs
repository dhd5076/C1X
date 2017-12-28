using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace C1X.Game
{
    public class Node
    {
        public static readonly float Friction = 10f;

        public Texture2D Texture2D { get; private set; }
        public Vector2 Position { get; protected set; }
        public Vector2 Velocity {get; protected set;}

        private string _privateKey;
        private string _publicKey;
        

        public Node()
        {
            //TODO:Get keys from crypto functions
        }

        public Node(Texture2D texture2D, Vector2 position)
        {
            this.Texture2D = texture2D;
            this.Position = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            this.Position += this.Velocity * (gameTime.ElapsedGameTime.Milliseconds / (1000f));
            if (this.Velocity.X > 0) this.Velocity -= new Vector2(Friction, 0);
            if (this.Velocity.X < 0) this.Velocity += new Vector2(Friction, 0);
            if (this.Velocity.Y > 0) this.Velocity -= new Vector2(0, Friction);
            if (this.Velocity.Y < 0) this.Velocity += new Vector2(0, Friction);
        }

        protected void AddForce(Vector2 forceVector)
        {
            this.Velocity += forceVector;
        }

        private static Guid GenGuid()
        {
            return Guid.NewGuid();
        }
    }
}
