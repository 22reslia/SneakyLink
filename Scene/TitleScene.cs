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
        private SoundEffect titleMusic;
        private ISprite background;
        private SoundEffectInstance menuSound;
        public TitleScene(Game1 game) 
        {
            //load the source
            scene = game.Content.Load<Texture2D>("TitleBackground");
            titleMusic = game.Content.Load<SoundEffect>("RoomMusic");

            background = new TitleBackgroundSprite(scene);
            menuSound = titleMusic.CreateInstance();
            menuSound.Volume = 0.25f;
            menuSound.IsLooped = true;
            menuSound.Play();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, 0, 0);
        }

        public void Unload()
        {
            menuSound.Stop();
        }
    }
}
