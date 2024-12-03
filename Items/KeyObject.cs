using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Items
{
    public class KeyObject : IItem
    {
        private ISprite keySprite;
        private int x, y;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public KeyObject(int positionX, int positionY)
        {
            keySprite = new KeySprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.roomItem, 24, 24, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            keySprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
        }
    }
}
