using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class CollisionBox : ICollision
    {
        public CollisionType side;
        public CollisionObjectType type;
        public int width, height;
        public int x, y;
        public CollisionBox (CollisionObjectType type, int width, int height, int x, int y)
        {
            this.type = type;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }
        public CollisionObjectType ObjectType => type;

        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            throw new NotImplementedException();
        }
    }
}
