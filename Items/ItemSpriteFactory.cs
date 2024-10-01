using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Items
{
    public class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextrues(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("Items");
        }

        public Texture2D GetSheet()
        {
            return itemSpriteSheet;
        }
    }
}
