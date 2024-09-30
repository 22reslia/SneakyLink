/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class Item : ISprite
    {
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        private int currentImageFrame;
        private int currentImageIndex;
        private int itemCount;
        private double frameTime;
        private double timeSinceLastFrame;
        public Item(Texture2D texture, double frameTime)
        {
            this.texture = texture;
            currentImageFrame = 0;
            currentImageIndex = 0;
            this.frameTime = frameTime;
            timeSinceLastFrame = 0;
            itemCount = 13;
            
        }

        public void Update()
        {
            
            if (timeSinceLastFrame > frameTime && (currentImageIndex == 4 || currentImageIndex == 7 || currentImageIndex == 8 || currentImageIndex == 11))
            {
                currentImageFrame = (currentImageFrame + 1) % sourceRectangles.Length;
                timeSinceLastFrame = 0;
            }
            else if (!(currentImageIndex == 4 || currentImageIndex == 7 || currentImageIndex == 8 || currentImageIndex == 11))
            {
                currentImageFrame = 0;
            }
            switch (currentImageIndex)
            {
                case 0:
                    sourceRectangles = setRectanglesItem.Instance.Compass();
                    break;
                case 1:
                    sourceRectangles = setRectanglesItem.Instance.Map();
                    break;
                case 2:
                    sourceRectangles = setRectanglesItem.Instance.Key();
                    break;
                case 3:
                    sourceRectangles = setRectanglesItem.Instance.HeartContainer();
                    break;
                case 4:
                    sourceRectangles = setRectanglesItem.Instance.TriforcePiece();
                    break;
                case 5:
                    sourceRectangles = setRectanglesItem.Instance.WoodenBoomerang();
                    break;
                case 6:
                    sourceRectangles = setRectanglesItem.Instance.Bow();
                    break;
                case 7:
                    sourceRectangles = setRectanglesItem.Instance.Heart();
                    break;
                case 8:
                    sourceRectangles = setRectanglesItem.Instance.Rupee();
                    break;
                case 9:
                    sourceRectangles = setRectanglesItem.Instance.Arrow();
                    break;
                case 10:
                    sourceRectangles = setRectanglesItem.Instance.Bomb();
                    break;
                case 11:
                    sourceRectangles = setRectanglesItem.Instance.Fairy();
                    break;
                case 12:
                    sourceRectangles = setRectanglesItem.Instance.Clock();
                    break;
            }
        }
        
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            Rectangle sourceRectangle = sourceRectangles[currentImageFrame];
            Rectangle destinationRectangle = new Rectangle(500, 200, 3*sourceRectangle.Width, 3*sourceRectangle.Height);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangles[currentImageFrame], Color.White);
            spriteBatch.End(); 
        }
        public void NextImage()
        {
            currentImageIndex = (currentImageIndex + 1) % itemCount;
        }
        public void PreviousImage()
        {
            currentImageIndex = (currentImageIndex - 1 + itemCount) % itemCount;
        }
    }
}
*/