using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Inventory
{
    public class InventoryScene : IScene
    {
        private Game1 game;
        private Texture2D infoText;
        private ISprite infoSprite;
        private Health health;
        public InventoryScene(Game1 game)
        {
            this.game = game;
            infoText = game.Content.Load<Texture2D>("InventoryBasicInfo");
            infoSprite = new BasicInfoSprite(infoText);
            health = new Health(game.link, infoText);
        }
        public void Update()
        {
            health.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            infoSprite.Draw(spriteBatch, 0, 0);
            health.Draw(spriteBatch);
        }
    }
}
