using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace SneakyLink
{
    public class Block : ISprite
    {
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        private int currentImageIndex;

        public Block(Texture2D texture, Rectangle[] sourceRectangles)
        {
            this.texture = texture;
            this.sourceRectangles = sourceRectangles;
            currentImageIndex = 0;
        }

        public void Update()
        {
           
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {   
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle(300, 200, 32, 32), sourceRectangles[currentImageIndex], Color.White);
            spriteBatch.End();
        }
        public void NextImage()
        {
            currentImageIndex = (currentImageIndex + 1) % sourceRectangles.Length;
        }
        public void PreviousImage()
        {
            currentImageIndex = (currentImageIndex - 1 + sourceRectangles.Length) % sourceRectangles.Length;
        }
    }
}
