using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;

namespace SneakyLink.Player
{
    public class Link
    {
        public Vector2 playerPosition;
        public PlayerStateMachine stateMachine;
        public CollisionBox collisionBox;
        public ISprite playerSprite;
        public int velocity;
        private int originalVelocity; // Store the original velocity
        float timer = 0f;
        float stopTime = 1f;

        // Collision states
        public bool isBlockedTop;
        public bool isBlockedBottom;
        public bool isBlockedLeft;
        public bool isBlockedRight;

        // HP
        public bool isV;
        public bool isMovable;
        public int maxHealth;
        public int currentHealth;

        // Sword damage
        public int damage;

        private int vCounter;
        private int mCounter;

        // Inventory
        public int coinNum;
        public int keyNum;
        public int bombNum;
        public bool hasBluepotion;
        public bool hasRedpotion;
        public bool isDrinkingRedpotion;

        // Potion timers
        private double drinkCounter;
        private double drinkDuration = 2.0;
        private double healCounter = 0.0;
        private double healTime = 1.0;

        // XP and Level
        public int experience;
        public int level;
        public int xpToNextLevel;

        public Link(Game1 game)
        {
            maxHealth = 5;
            currentHealth = maxHealth;
            isV = false;
            isMovable = true;

            velocity = 3;  // Set initial velocity
            originalVelocity = velocity;  // Store the original velocity
            playerPosition.X = 100;
            playerPosition.Y = 100;

            isBlockedTop = false;
            isBlockedBottom = false;
            isBlockedLeft = false;
            isBlockedRight = false;

            vCounter = 0;
            mCounter = 0;

            // State machine
            stateMachine = new PlayerStateMachine(playerPosition, this, game);
            collisionBox = new CollisionBox(CollisionObjectType.Player, 38, 38, (int)playerPosition.X, (int)playerPosition.Y);

            coinNum = 0;
            keyNum = 0;
            bombNum = 0;
            hasBluepotion = false;
            hasRedpotion = false;
            isDrinkingRedpotion = false;
            damage = 1;  // Default damage

            // Initialize XP and level
            level = 1;
            experience = 0;
            xpToNextLevel = 60; // Initial XP needed to level up
        }

        public void SetSprite()
        {
            playerSprite = stateMachine.GetCurrentIdleSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (playerSprite != null)
            {
                stateMachine.Draw(spriteBatch, playerSprite, (int)playerPosition.X, (int)playerPosition.Y);
            }
        }

        public void Update(GameTime gameTime)
        {
            playerSprite = stateMachine.Update(gameTime);
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= stopTime)
            {
                stateMachine.currentState = PlayerState.playerIdle;
                timer = 0f;
            }
            else
            {
                timer += deltaTime;
            }

            collisionBox.x = (int)playerPosition.X;
            collisionBox.y = (int)playerPosition.Y;

            if (collisionBox.side == CollisionType.None)
            {
                isBlockedTop = false;
                isBlockedBottom = false;
                isBlockedLeft = false;
                isBlockedRight = false;
            }

            // Update invincibility
            if (isV)
            {
                vCounter++;
                if (vCounter == 60)
                {
                    isV = false;
                    vCounter = 0;
                }
            }

            // Update movement state
            if (collisionBox.side == CollisionType.None)
            {
                mCounter++;
                if (mCounter == 50)
                {
                    isMovable = true;
                    mCounter = 0;
                }
            }

            // Check potion consumption
            if (isDrinkingRedpotion)
            {
                if (drinkCounter == 0)
                {
                    drinkCounter = drinkDuration;
                    originalVelocity = velocity;  // Store original velocity before slowing down
                    velocity -= 2;  // Slow down velocity by 2
                }

                drinkCounter -= gameTime.ElapsedGameTime.TotalSeconds;
                healCounter += gameTime.ElapsedGameTime.TotalSeconds;
                if (healCounter >= healTime)
                {
                    if (currentHealth < maxHealth)
                    {
                        currentHealth++;
                    }
                    healCounter -= healTime;
                }

                if (drinkCounter <= 0)
                {
                    isDrinkingRedpotion = false;
                    drinkCounter = 0;
                    healCounter = 0;
                    velocity = originalVelocity;  // Restore the original velocity after the potion effect ends
                }
            }

            playerSprite.Update();
        }

        public void GainExperience(int xp)
        {
            experience += xp;
            if (experience >= xpToNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            experience -= xpToNextLevel;
            level++;

            damage += 1;

            xpToNextLevel = (int)(xpToNextLevel * 1.5); // XP curve
        }
    }
}
