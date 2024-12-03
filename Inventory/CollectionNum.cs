using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Inventory
{
    public class CollectionNum
    {
        private int coinNum;
        private int keyNum;
        private int bombNum;
        private Link link;
        private Texture2D numberText;
        private CollectionNumSprite numSprite;

        public CollectionNum(Link link, Texture2D numberText)
        {
            coinNum = link.coinNum;
            keyNum = link.keyNum;
            bombNum = link.bombNum;
            this.link = link;
            numSprite = new CollectionNumSprite(numberText, coinNum, keyNum, bombNum);
        }

        public void Update()
        {
            numSprite.UpdateNum(link.coinNum, link.keyNum, link.bombNum);
        }
        public void Draw(SpriteBatch spriteBatch, bool isInInventory)
        {
            int x = 42;
            int y = 48;
            if (!isInInventory)
            {
                y += 460;
            }
            numSprite.Draw(spriteBatch, x, y);
        }
    }
}
