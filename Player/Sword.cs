using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink.Player
{
    public class Sword
    {
        private int x, y;
        public CollisionBox collisionBox;

        public Sword(int x, int y)
        {
            this.x = x;
            this.y = y;
            collisionBox = new CollisionBox(CollisionObjectType.Player, 24, 32, x, y);
        }
    }
}
