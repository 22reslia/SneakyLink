using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Inventory
{
    public class ItemShown
    {
        private WeaponListSprite weaponListSprite;
        private ItemListSprite itemListSprite;
        public ItemShown(Link link, Texture2D infoText)
        {
            //TO-DO:change this two line's string into player item information after finish item part
            weaponListSprite = new WeaponListSprite("WoodSword", infoText);
            itemListSprite = new ItemListSprite("Bomb", infoText);

        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch, bool isInInventory)
        {
            int x = 138;
            int y = 72;
            if (!isInInventory)
            {
                y += 460;
            }
            weaponListSprite.Draw(spriteBatch, x, y);
            itemListSprite.Draw(spriteBatch, x + 71, y);
        }
    }
}
