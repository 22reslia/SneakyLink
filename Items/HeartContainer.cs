using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink.Items
{
    public class HeartContainer : IItem
    {
        private ISprite heartContainerSprite;
        private int x, y;
        private CollisionBox collisionBox;

        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public HeartContainer(int positionX, int positionY)
        {
            heartContainerSprite = new HeartContainerSprite();
            x = positionX;
            y = positionY;

            //unsure about dimensions
            collisionBox = new CollisionBox(CollisionObjectType.roomItem, 39, 39, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            heartContainerSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
            // Any logic for updating the item state, if necessary
        }
    }
}
