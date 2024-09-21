using System.Diagnostics.Contracts;
using System.Numerics;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Enemies;

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
            stateMachine = new PlayerStateMachine();
        }

        public void SetSprite()
        {
            playerSprite = stateMachine.GetCurrentSprite();
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
            //calls the ISprite update for given sprite
            playerSprite.Update();
            playerSprite = stateMachine.Update();
        }
    }