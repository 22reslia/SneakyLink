using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using SneakyLink.Collision;

namespace SneakyLink.Items
{
    public class PushableBlock : IItem
    {
        private ISprite squareBlockSprite;
        private int x, y;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }
        public bool isPushedRight, isPushedLeft, isPushedUp, isPushedDown;

        public PushableBlock(int positionX, int positionY)
        {
            squareBlockSprite = new SquareBlockSprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Block, 40, 40, x, y);
            isPushedRight = false;
            isPushedLeft = false;
            isPushedUp = false;
            isPushedDown = false;
        }

        public void Push(Vector2 direction)
        {
            if (isPushedRight)
            {
                x += (int)direction.X / 10;
            }
            else if (isPushedLeft)
            {
                x -= (int)direction.X / 10;
            }
            else if (isPushedUp)
            {
                y += (int)direction.Y / 10;
            }
            else if (isPushedDown)
            {
                x -= (int)direction.Y / 10;
            }
            CollisionBox = new CollisionBox(CollisionObjectType.Block, 40, 40, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            squareBlockSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
        }
    }
}
