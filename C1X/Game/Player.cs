using System;
using System.Collections.Generic;
using System.Linq;
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

        public Player() : base() { }
        public Player(Texture2D texture2D, Vector2 position) : base(texture2D, position) { }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            #region Move with input
            var up = keyboardState.IsKeyDown(Keys.W);
            var down = keyboardState.IsKeyDown(Keys.S);
            var left = keyboardState.IsKeyDown(Keys.A);
            var right = keyboardState.IsKeyDown(Keys.D);

            if(up && down) C1XGame.PeerNetwork.Broadcast("Bit");

            if (up && !down && this.Velocity.Y > -Speed) this.Velocity += new Vector2(0, -20);
            else if (down && !up && this.Velocity.Y < Speed) this.Velocity += new Vector2(0, 20);


            if (left && !right && this.Velocity.X > -Speed) this.Velocity += new Vector2(-20, 0);
            else if (right && !left && this.Velocity.X < Speed) this.Velocity += new Vector2(20, 0);
            #endregion

            base.Update(gameTime);
        }
    }
}
