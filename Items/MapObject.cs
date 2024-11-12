using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Items
{
    public class MapObject : IItem
    {
        private ISprite mapSprite;
        private int x, y;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value;}

        public MapObject(int positionX, int positionY)
        {
            mapSprite = new MapSprite();
            x = positionX; 
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.roomItem, 24, 24, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mapSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
    }
}
