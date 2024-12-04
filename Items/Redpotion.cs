using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink.Items
{
    public class RedPotion : IItem
    {
        private ISprite redPotionSprite;
        private int x, y;
        private CollisionBox collisionBox;

        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public RedPotion(int positionX, int positionY)
        {
            redPotionSprite = new RedpotionSprite();
            x = positionX;
            y = positionY;

            // Adjust collision box dimensions as needed
            collisionBox = new CollisionBox(CollisionObjectType.roomItem, 24, 24, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            redPotionSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
            // Any logic for updating the item's state, if necessary
        }
    }
}
