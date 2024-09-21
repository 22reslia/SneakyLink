using System.Diagnostics.Contracts;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Enemies;

namespace SneakyLink.Player;
    public class Player
    {
        int health;
        Vector2 playerPosition;
        private PlayerStateMachine stateMachine;
        public ISprite playerSprite;
        public Player()
        {
            health = 10;
            playerPosition.X = 100;
            playerPosition.Y = 100;
            stateMachine = new PlayerStateMachine();
            playerSprite = stateMachine.GetCurrentSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, playerSprite, (int)playerPosition.X, (int)playerPosition.Y);
        }

        public void Update()
        {
            playerSprite.Update();
        }

    }