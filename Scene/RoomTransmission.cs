using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Scene
{
    public class RoomTransmission
    {
        private float transitionProgress;
        public bool isTransitioningIn;
        public bool isTransmissionComplete;
        private float pauseTimer;
        private float transitionSpeed;
        private float pauseDuration;
        private Texture2D blackText;
        public RoomTransmission(GraphicsDevice graphicsDevice)
        {
            transitionProgress = 0f;
            isTransitioningIn = true;
            isTransmissionComplete = false;
            pauseTimer = 0f;
            transitionSpeed = 1f;
            pauseDuration = 1f;
            blackText = new Texture2D(graphicsDevice, 1, 1);
            blackText.SetData(new[] { Color.Black });
        }

        public void Update(GameTime gameTime)
        {
            if (isTransitioningIn)
            {
                transitionProgress += transitionSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (transitionProgress >= 1f)
                {
                    transitionProgress = 1f;
                    isTransitioningIn = false;
                    pauseTimer = pauseDuration;
                }
            }
            else if (pauseTimer > 0)
            {
                pauseTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                transitionProgress -= transitionSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(transitionProgress <= 0f)
                {
                    transitionProgress = 0f;
                    isTransmissionComplete = true;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, Room oldRoom, Room newRoom)
        {
            if (isTransitioningIn)
            {
                oldRoom.Draw(spriteBatch);
            }
            else
            {
                newRoom.Draw(spriteBatch);
            }


            float blackHeight = 640 * transitionProgress;
            Rectangle blackRectangle = new Rectangle(0, 640 - (int)blackHeight, 800, (int)blackHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(blackText, blackRectangle, Color.Black);
            spriteBatch.End();
        }


        public void reset()
        {
            transitionProgress = 0f;
            isTransitioningIn = true;
            pauseTimer = 0f;
            isTransmissionComplete = false;
        }
    }
}
