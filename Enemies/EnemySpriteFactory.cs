﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class EnemySpriteFactory
    {
        private Texture2D dungeonEnemySpriteSheet;
        private Texture2D bossesSpriteSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            dungeonEnemySpriteSheet = content.Load<Texture2D>("DungeonEnemies");
            bossesSpriteSheet = content.Load<Texture2D>("Bosses");
        }

        public ISprite CreateKeeseEnemySprite()
        {
            return new KeeseSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateStalfosEnemySprite()
        {
            return new StalfosSprite(dungeonEnemySpriteSheet);
        }

    }
}

