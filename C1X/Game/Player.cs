using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace C1X.Game
{
    public class Player : Node
    {
        public Player() : base() { }
        public Player(Texture2D texture2D, Vector2 position) : base(texture2D, position) { }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
