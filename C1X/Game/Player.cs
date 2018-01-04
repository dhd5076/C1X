using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace C1X.Game
{
    public class Player : Node
    {
        public static readonly float Speed = 200f;
        public static readonly float Acceleration = 10f;

        public Player(Socket socket) : base(socket, true) { }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var diff = mouseState.Position.ToVector2() - Position;
            var angle = (float)Math.Atan2((float)diff.Y, (float)diff.X);

            if ((Math.Abs(diff.X) > 1 || Math.Abs(diff.Y) > 1) && mouseState.RightButton == ButtonState.Pressed)
            {
                this.Velocity = new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)) * new Vector2(2f, 2f);
            }
            else
            {
                this.Velocity = new Vector2(0,0);
            }

            base.Update(gameTime);
        }
    }
}
