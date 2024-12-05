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
    public class Health
    {
        private int maxHealth;
        private int health;
        private Link link;
        private HeartSprite fullHeart;
        private HeartSprite emptyHeart;
        public Health(Link link, Texture2D heartText)
        {
            maxHealth = link.maxHealth;
            health = link.currentHealth;
            this.link = link;

            fullHeart = new HeartSprite(heartText, false);
            emptyHeart = new HeartSprite(heartText, true);
        }
        public void Update()
        {
            maxHealth = link.maxHealth;
            health = link.currentHealth;
        }
        public void Draw(SpriteBatch spriteBatch, bool isInInventory)
        {
            int heartSize = 24;
            int heartPerRow = 8;
            int x = 282;
            int y = 96;
            if (!isInInventory)
            {
                y += 460;
            }
            for (int i = 0; i < maxHealth; i ++)
            {
                //draw the hearts based on current health
                if (i < health)
                {
                    fullHeart.Draw(spriteBatch, x, y);
                }
                else
                {
                    emptyHeart.Draw(spriteBatch, x, y);
                }
                //change drawing x position each heart
                x += heartSize;
                //if the heart filled one row then change y poistion
                if ((i + 1) % heartPerRow == 0)
                {
                    x = 282;
                    y += heartSize;
                }
            }
        }
    }
}
