using System.Diagnostics.Contracts;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;
    public class Link
    {
        public Vector2 playerPosition;
        public PlayerStateMachine stateMachine;
        public ISprite playerSprite;
        public int velocity;

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

        public void Update()
        {   
            //updates the sprite based off the change of state
            playerSprite = stateMachine.Update();

            if (!stateMachine.LinkPositionIdle())
            {
                stateMachine.currentState = PlayerState.playerIdle;
            }

            //calls the ISprite update for given sprite
            playerSprite.Update();
        }
    }