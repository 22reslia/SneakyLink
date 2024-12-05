using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink.Items
{
    public class BluePotion : IItem
    {
        private ISprite bluePotionSprite;
        private int x, y;
        private CollisionBox collisionBox;

        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public BluePotion(int positionX, int positionY)
        {
            bluePotionSprite = new BluepotionSprite();
            x = positionX;
            y = positionY;

            // Adjust collision box dimensions as needed
            collisionBox = new CollisionBox(CollisionObjectType.roomItem, 24, 24, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bluePotionSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
            // Any logic for updating the item's state, if necessary
        }
    }
}
