using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string nextRoomFilePath;
        private System.Numerics.Vector2 nextLinkPosition;
        public System.Numerics.Vector2 NextLinkPosition { get => nextLinkPosition; set => nextLinkPosition = value; }
        public string NextRoomFilePath {  get => nextRoomFilePath; set => nextRoomFilePath = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }
        public Doors(String doorID, int positionX, int positionY, string nextRoomFilePath)
        {
            col = doorID[doorID.Length - 2] - '0';
            row = doorID[doorID.Length - 1] - '0';
            this.positionX = positionX;
            this.positionY = positionY;
            image = BlockSpriteFactory.Instance.GetSheet();
            collisionBox = new CollisionBox(CollisionObjectType.Block, 80, 80, positionX, positionY);

            //set the room transmission info
            Debug.Print(doorID + nextRoomFilePath);
            this.nextRoomFilePath = nextRoomFilePath;
            switch (col)
            {
                case 3:
                    nextLinkPosition = new System.Numerics.Vector2(389, 110);
                    break;
                case 2:
                    nextLinkPosition = new System.Numerics.Vector2(170, 209);
                    break;
                case 0:
                    nextLinkPosition = new System.Numerics.Vector2(357, 330);
                    break;
                case 1:
                    nextLinkPosition = new System.Numerics.Vector2(590, 200);
                    break;
            }
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
