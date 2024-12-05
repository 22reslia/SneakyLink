using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Inventory
{
    public class MapShown
    {
        private MapShownSprite UpBlock;
        private MapShownSprite DownBlock;
        private MapShownSprite BothBlock;
        private MapShownSprite playerPoint;
        public MapShown(Texture2D mapText)
        {
            UpBlock = new MapShownSprite(mapText, 0);
            DownBlock = new MapShownSprite(mapText, 1);
            BothBlock = new MapShownSprite(mapText, 2);
            playerPoint = new MapShownSprite(mapText, 3);
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, bool isInInventory, int roomNumber)
        {
            int x = 500;
            int y = 50;
            int squareLength = 24;
            if (!isInInventory)
            {
                y += 460;
            }
            UpBlock.Draw(spriteBatch, x + squareLength, y);
            UpBlock.Draw(spriteBatch, x, y + squareLength);
            UpBlock.Draw(spriteBatch, x + squareLength * 4, y + squareLength);
            UpBlock.Draw(spriteBatch, x + squareLength * 2, y + squareLength * 3);
            DownBlock.Draw(spriteBatch, x + squareLength * 4, y);
            DownBlock.Draw(spriteBatch, x + squareLength * 5, y);
            DownBlock.Draw(spriteBatch, x + squareLength, y + squareLength * 2);
            DownBlock.Draw(spriteBatch, x + squareLength * 3, y + squareLength * 2);
            BothBlock.Draw(spriteBatch, x + squareLength * 2, y);
            BothBlock.Draw(spriteBatch, x + squareLength, y + squareLength);
            BothBlock.Draw(spriteBatch, x + squareLength * 2, y + squareLength);
            BothBlock.Draw(spriteBatch, x + squareLength * 3, y + squareLength);
            BothBlock.Draw(spriteBatch, x + squareLength * 2, y + squareLength * 2);

            switch (roomNumber)
            {
                case 0:
                    playerPoint.Draw(spriteBatch, x + squareLength * 2, y + squareLength * 3);
                    break;
                case 1:
                    playerPoint.Draw(spriteBatch, x + squareLength, y + squareLength * 2 + 12);
                    break;
                case 2:
                    playerPoint.Draw(spriteBatch, x + squareLength * 2, y + squareLength * 2 + 12);
                    break;
                case 3:
                    playerPoint.Draw(spriteBatch, x + squareLength * 3, y + squareLength * 2 + 12);
                    break;
                case 4:
                    playerPoint.Draw(spriteBatch, x + squareLength * 2, y + squareLength * 2);
                    break;
                case 5:
                    playerPoint.Draw(spriteBatch, x + squareLength, y + squareLength + 12);
                    break;
                case 6:
                    playerPoint.Draw(spriteBatch, x + squareLength * 2, y + squareLength + 12);
                    break;
                case 7:
                    playerPoint.Draw(spriteBatch, x + squareLength * 3, y + squareLength + 12);
                    break;
                case 8:
                    playerPoint.Draw(spriteBatch, x, y + squareLength);
                    break;
                case 9:
                    playerPoint.Draw(spriteBatch, x + squareLength, y + squareLength);
                    break;
                case 10:
                    playerPoint.Draw(spriteBatch, x + squareLength * 2, y + squareLength);
                    break;
                case 11:
                    playerPoint.Draw(spriteBatch, x + squareLength * 3, y + squareLength);
                    break;
                case 12:
                    playerPoint.Draw(spriteBatch, x + squareLength * 4, y + squareLength);
                    break;
                case 13:
                    playerPoint.Draw(spriteBatch, x + squareLength * 2, y + 12);
                    break;
                case 14:
                    playerPoint.Draw(spriteBatch, x + squareLength * 4, y + 12);
                    break;
                case 15:
                    playerPoint.Draw(spriteBatch, x + squareLength * 5, y + 12);
                    break;
                case 16:
                    playerPoint.Draw(spriteBatch, x + squareLength, y);
                    break;
                case 17:
                    playerPoint.Draw(spriteBatch, x + squareLength * 2, y);
                    break;
            }

        }

    }
}
