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
        public bool isBlockedRight, isBlockedLeft, isBlockedUp, isBlockedDown;

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
            isBlockedRight = false;
            isBlockedLeft = false;
            isBlockedUp = false;
            isBlockedDown = false;
        }

        public void Push()
        {
            if (isPushedRight)
            {
                x += 15;
            }
            else if (isPushedLeft)
            {
                x -= 15;
            }
            else if (isPushedUp)
            {
                y -= 15;
            }
            else if (isPushedDown)
            {
                y += 15;
            }
            CollisionBox = new CollisionBox(CollisionObjectType.Block, 40, 40, x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            squareBlockSprite.Draw(spriteBatch, x, y);
        }

        public void CheckPush(CollisionBox linkCollisionBox)
        {
            isPushedRight = false;
            isPushedLeft = false;
            isPushedUp = false;
            isPushedDown = false;

            if (linkCollisionBox.x + linkCollisionBox.width > collisionBox.x &&
                linkCollisionBox.x < collisionBox.x + collisionBox.width &&
                linkCollisionBox.y + linkCollisionBox.height > collisionBox.y &&
                linkCollisionBox.y < collisionBox.y + collisionBox.height)
            {
                if (linkCollisionBox.x < collisionBox.x)
                {
                    isPushedRight = true;
                }
                else if (linkCollisionBox.x > collisionBox.x)
                {
                    isPushedLeft = true;
                }
                else if (linkCollisionBox.y < collisionBox.y)
                {
                    isPushedDown = true;
                }
                else if (linkCollisionBox.y > collisionBox.y)
                {
                    isPushedUp = true;
                }
            }
        }

        public void Update()
        {
        }
    }
}
