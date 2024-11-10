using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Items
{
    public class RupeeObject : IItem
    {
        private ISprite RupeeSprite;
        private int x, y;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public RupeeObject(int positionX, int positionY)
        {
            RupeeSprite = new MapSprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Interactive, 24, 48, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            RupeeSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
            RupeeSprite.Update();
        }
    }
}
