using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Game
{
    abstract class Node
    {
        public Sprite Sprite { get; set;  }
        public CircleCollider CircleCollider { get; set; }

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
