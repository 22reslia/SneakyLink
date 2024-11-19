using Microsoft.Xna.Framework.Audio;
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
        private Texture2D titleInfo;
        private SoundEffect titleMusic;
        private ISprite background;
        private ISprite title;
        private SoundEffectInstance menuSound;
        public TitleScene(Game1 game) 
        {
            //load the source
            scene = game.Content.Load<Texture2D>("TitleBackground");
            titleInfo = game.Content.Load<Texture2D>("TitleInfo");
            titleMusic = game.Content.Load<SoundEffect>("RoomMusic");

            background = new TitleBackgroundSprite(scene);
            title = new TitleWordSprite(titleInfo);
            menuSound = titleMusic.CreateInstance();
            menuSound.Volume = 0.2f;
            menuSound.IsLooped = true;
            menuSound.Play();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, -160, -160);
            title.Draw(spriteBatch, 0, 100);
        }

        public void Unload()
        {
            menuSound.Stop();
        }
    }
}
