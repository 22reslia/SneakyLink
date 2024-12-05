using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class Sand : IBlock
    {
        private ISprite blueSandSprite;
        private int x, y;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }
        public Sand(int positionX, int positionY) { 
            blueSandSprite = new BlueSandSprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Sand, 40, 40, x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            blueSandSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
            
        }
    }
}
