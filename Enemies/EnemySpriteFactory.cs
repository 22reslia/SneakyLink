using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Enemies
{
    public class EnemySpriteFactory
    {
        private Texture2D dungeonEnemySpriteSheet;
        private Texture2D bossesSpriteSheet;
        private Texture2D deathSpriteSheet;

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
            deathSpriteSheet = content.Load<Texture2D>("EnemyDeath");
        }

        public ISprite CreateEnemyDeathSprite()
        {
            return new EnemyDeathSprite(deathSpriteSheet);
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
        public ISprite CreateAquamentusLeftAttackEnemySprite()
        {
            return new AquamentusLeftAttackSprite(bossesSpriteSheet);
        }
        public ISprite CreateAquamentusRightIdleEnemySprite()
        {
            return new AquamentusRightIdleSprite(bossesSpriteSheet);
        }
        public ISprite CreateAquamentusRightAttackEnemySprite()
        {
            return new AquamentusRightAttackSprite(bossesSpriteSheet);
        }
        public ISprite CreateAquamentusFireBall()
        {
            return new AquamentusFireBallSprite(bossesSpriteSheet);
        }
        public ISprite CreateGoriyaRightIdleSprite()
        {
            return new GoriyaRightIdleSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateGoriyaLeftIdleSprite()
        {
            return new GoriyaLeftIdleSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateGoriyaUpIdleSprite()
        {
            return new GoriyaUpIdleSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateGoriyaDownIdleSprite()
        {
            return new GoriyaDownIdleSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateGoriyaBoomerangSprite()
        {
            return new GoriyaBoomerangSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateGoriyaRightAttackSprite()
        {
            return new GoriyaRightAttackSprite(dungeonEnemySpriteSheet);
        }

        public ISprite CreateGoriyaLeftAttackSprite()
        {
            return new GoriyaLeftAttackSprite(dungeonEnemySpriteSheet);
        }
    }
}

