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
    public class Doors : IBlock
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private int col;
        private int row;
        private int positionX;
        private int positionY;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }
        public Doors(String doorID, int positionX, int positionY)
        {
            col = doorID[doorID.Length - 2] - '0';
            row = doorID[doorID.Length - 1] - '0';
            this.positionX = positionX;
            this.positionY = positionY;
            image = BlockSpriteFactory.Instance.GetSheet();
            collisionBox = new CollisionBox(CollisionObjectType.Interactive, 40, 40, positionX, positionY);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sourceRectangle = new Rectangle(815 + row*33, 11 + col*33, 32, 32);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(positionX, positionY, 80, 80), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
