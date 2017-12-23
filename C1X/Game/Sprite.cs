using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace C1X.Game
{
    public class Sprite
    {
        private Texture2D Texture2D;
        public Sprite(string spriteImage)
        {
            try
            {
                this.Texture2D = C1XGame.Instance.Content.Load<Texture2D>(spriteImage);
            }
            catch(Exception e)
            {
                throw new Exception("Failed to load texture: \"" + spriteImage + "\"", e);
            }
        }
    }
}
