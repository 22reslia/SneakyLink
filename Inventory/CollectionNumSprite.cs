using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SneakyLink.Inventory
{
    public class CollectionNumSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private int coinNum;
        private int keyNum;
        private int bombNum;
        public CollectionNumSprite(Texture2D text, int coinNum, int keyNum, int bombNum)
        {
            image = text;
            this.coinNum = coinNum;
            this.keyNum = keyNum;
            this.bombNum = bombNum;  
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            DrawNum(spriteBatch, x, y, coinNum);
            DrawNum(spriteBatch, x, y + 48, keyNum);
            DrawNum(spriteBatch, x, y + 72, bombNum);
            spriteBatch.End();
        }

        public void DrawNum(SpriteBatch spriteBatch, int x, int y, int num)
        {
            //draw 'X'
            sourceRectangle = new Rectangle(519, 117, 8, 8);
            spriteBatch.Draw(image, new Rectangle(x, y, 24, 24), sourceRectangle, Color.White);

            //draw first digit
            int first = num / 10;
            sourceRectangle = new Rectangle(519 + 9 * (first + 1), 117, 8, 8);
            spriteBatch.Draw(image, new Rectangle(x + 24, y, 24, 24), sourceRectangle, Color.White);

            //draw second digit
            int second = num % 10;
            sourceRectangle = new Rectangle(519 + 9 * (second + 1), 117, 8, 8);
            spriteBatch.Draw(image, new Rectangle(x + 48, y, 24, 24), sourceRectangle, Color.White);
        }

        public void UpdateNum(int coinNum, int keyNum, int bombNum)
        {
            this.coinNum = coinNum;
            this.keyNum = keyNum;
            this.bombNum = bombNum;
        }

        public void Update()
        {
        }
    }
}
