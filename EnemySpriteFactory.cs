using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
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

        public ISprite CreateGelSprite()
        {
            return new GelSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateZolSprite()
        {
            return new ZolSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateAquamentusLeftIdleEnemySprite()
        {
            return new AquamentusLeftIdleSprite(bossesSpriteSheet);
        }
        public ISprite CreateAquamentusRightIdleEnemySprite()
        {
            return new AquamentusRightIdleSprite(bossesSpriteSheet);
        }
        public ISprite CreateAquamentusFireBall()
        {
            return new AquamentusFireBall(bossesSpriteSheet);
        }

    }
}

