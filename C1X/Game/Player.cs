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
        public static readonly float Speed = 2f;
        public static readonly float Acceleration = 0.02f;

        public Player(Socket socket) : base(socket, true) { }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            #region Move with input
            var up = keyboardState.IsKeyDown(Keys.W);
            var down = keyboardState.IsKeyDown(Keys.S);
            var left = keyboardState.IsKeyDown(Keys.A);
            var right = keyboardState.IsKeyDown(Keys.D);

            if(up && down) C1XGame.NodeNetwork.Broadcast("Bit");

            if (up && !down && this.Velocity.Y > -Speed) this.Velocity += new Vector2(0, -Acceleration);
            else if (down && !up && this.Velocity.Y < Speed) this.Velocity += new Vector2(0, Acceleration);


            if (left && !right && this.Velocity.X > -Speed) this.Velocity += new Vector2(-Acceleration, 0f);
            else if (right && !left && this.Velocity.X < Speed) this.Velocity += new Vector2(Acceleration, 0f);
            #endregion

            base.Update(gameTime);
        }
    }
}
