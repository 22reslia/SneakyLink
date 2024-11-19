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
        private CollectionNum CollectionNum;
        private ItemShown itemShown;
        public InventoryScene(Game1 game)
        {
            this.game = game;
            infoText = game.Content.Load<Texture2D>("InventoryBasicInfo");
            infoSprite = new BasicInfoSprite(infoText);
            health = new Health(game.link, infoText);
            CollectionNum = new CollectionNum(game.link, infoText);
            itemShown = new ItemShown(game.link, infoText);
        }
        public void Update()
        {
            health.Update();
            CollectionNum.Update();
            itemShown.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            infoSprite.Draw(spriteBatch, 0,0);
            health.Draw(spriteBatch, true);
            CollectionNum.Draw(spriteBatch, true);
            itemShown.Draw(spriteBatch, true);
        }
        public void DrawOnScene(SpriteBatch spriteBatch)
        {
            infoSprite.Draw(spriteBatch, 0, 460);
            health.Draw(spriteBatch, false);
            CollectionNum.Draw(spriteBatch, false);
            itemShown.Draw(spriteBatch, false);
        }
    }
}
