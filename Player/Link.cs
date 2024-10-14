using System.Diagnostics.Contracts;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Enemies;

namespace SneakyLink.Player;
public class Link
    {
        public Vector2 playerPosition;
        public PlayerStateMachine stateMachine;
        public CollisionBox collisionBox;
        public ISprite playerSprite;
        public int velocity;
        float timer = 0f;
        float stopTime = 1f;

    //creats a player with basic stats
    public Link()
        {
            velocity = 5;
            playerPosition.X = 100;
            playerPosition.Y = 100;

            //creates a state machine and gets the current sprite based on directional movement
            stateMachine = new PlayerStateMachine(playerPosition);
            collisionBox = new CollisionBox(CollisionObjectType.Player, 40, 40, (int)playerPosition.X, (int)playerPosition.Y);
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
            //updates the sprite based off the change of state
            playerSprite = stateMachine.Update(gameTime);
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!stateMachine.LinkPositionIdle() && stateMachine.currentState != PlayerState.playerDamaged || timer >= stopTime)
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

            //calls the ISprite update for given sprite
            playerSprite.Update();
        }
}