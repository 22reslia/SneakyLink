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
        private Vector2 position;

        public PushableBlock(int positionX, int positionY)
        {
            squareBlockSprite = new SquareBlockSprite();
            x = positionX;
            y = positionY;
            position = new Vector2(x, y);
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
                position.X += direction.X / 10;               
            }
            else if (isPushedLeft)
            {
                position.X -= direction.X / 10;
            }
            else if (isPushedUp)
            {
                position.Y += direction.Y / 10;
            }
            else if (isPushedDown)
            {
                position.Y -= direction.Y / 10;
            }
            CollisionBox = new CollisionBox(CollisionObjectType.Block, 40, 40, (int)position.X, (int)position.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            squareBlockSprite.Draw(spriteBatch, (int)position.X, (int)position.Y);
        }

        public void Update()
        {
        }
    }
}
