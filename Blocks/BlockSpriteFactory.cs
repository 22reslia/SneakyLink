using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextrues(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("Blocks");
        }

        public Texture2D GetSheet()
        {
            return blockSpriteSheet;
        }
    }
}
