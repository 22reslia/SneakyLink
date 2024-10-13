using System.Diagnostics.Contracts;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Enemies;

namespace SneakyLink.Player;
    public class Link : ICollision
    {
        public Vector2 playerPosition;
        public PlayerStateMachine stateMachine;
        public ISprite playerSprite;
        public int velocity;
        public int width = 40, height = 40;
        float timer = 0f;
        float stopTime = 1f;

    public Rectangle CollisionBox => new Rectangle((int)playerPosition.X, (int)playerPosition.Y, width, height);

    public CollisionObjectType ObjectType => throw new System.NotImplementedException();

    //creats a player with basic stats
    public Link()
        {
            velocity = 5;
            playerPosition.X = 100;
            playerPosition.Y = 100;

            //creates a state machine and gets the current sprite based on directional movement
            stateMachine = new PlayerStateMachine(playerPosition);
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

            //calls the ISprite update for given sprite
            playerSprite.Update();
        }

    public void OnCollision(ICollision other, CollisionType collisionType)
    {
        throw new System.NotImplementedException();
    }
}