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
            KeyboardState keyboardState = Keyboard.GetState();

            #region Move with input
            bool Up = keyboardState.IsKeyDown(Keys.W);
            bool Down = keyboardState.IsKeyDown(Keys.S);
            bool Left = keyboardState.IsKeyDown(Keys.A);
            bool Right = keyboardState.IsKeyDown(Keys.D);

            if (Up && !Down && this.Velocity.Y > -Speed) this.Velocity += new Vector2(0, -20);
            else if (Down && !Up && this.Velocity.Y < Speed) this.Velocity += new Vector2(0, 20);


            if (Left && !Right && this.Velocity.X > -Speed) this.Velocity += new Vector2(-20, 0);
            else if (Right && !Left && this.Velocity.X < Speed) this.Velocity += new Vector2(20, 0);
            #endregion

            base.Update(gameTime);
        }
    }
}
