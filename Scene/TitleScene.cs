using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Scene
{
    public class TitleScene : IScene
    {
        private Texture2D scene;
        private ISprite background;
        private Song titleMusic;
        public TitleScene(Game1 game) 
        {
            scene = game.Content.Load<Texture2D>("TitleBackground");
            titleMusic = game.Content.Load<Song>("TitleMusic");
            background = new TitleBackgroundSprite(scene);

            MediaPlayer.Play(titleMusic);
            MediaPlayer.IsRepeating = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, 0, 0);
        }
    }
}
