using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Numerics;

namespace SneakyLink.Scene
{
    public class GameOverScene
    {
        private string gameOverMessage = "You Lose";
        private string gameWinMessage = "You Win";
        private Game1 game;
        private SpriteFont textFont;
        public GameOverScene(Game1 game)
        {
            this.game = game;
            textFont = game.Content.Load<SpriteFont>("GameOverFont");
        }
        public void Draw(SpriteBatch spriteBatch, bool isWin)
        {
            spriteBatch.Begin();
            if (isWin)
            {
                spriteBatch.DrawString(textFont, gameWinMessage, new Microsoft.Xna.Framework.Vector2(250, 200), Color.White);
            }
            else
            {
                spriteBatch.DrawString(textFont, gameOverMessage, new Microsoft.Xna.Framework.Vector2(250, 200), Color.White);
            }
            string message1 = "Press R to reset";
            spriteBatch.DrawString(textFont, message1, new Microsoft.Xna.Framework.Vector2(200, 250), Color.White);
            string message2 = " Press Q to quit";
            spriteBatch.DrawString(textFont, message2, new Microsoft.Xna.Framework.Vector2(200, 300), Color.White);
            spriteBatch.End();
        }
    }
}
