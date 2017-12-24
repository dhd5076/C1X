using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Game
{
    public class Enemy : Node
    {

        public Enemy() : base() { }
        public Enemy(Texture2D texture2D, Vector2 position) : base(texture2D, position) { }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
