using Microsoft.Xna.Framework.Audio;

namespace SneakyLink.Items
{
    public class ItemSounds
    {
        private SoundEffect getRupeeMusic;
        private SoundEffectInstance rupeeSoundInstance;
        private bool isMuted = false; // Tracks the mute state

        public void LoadItemSoundEffects(Game1 game)
        {
            getRupeeMusic = game.Content.Load<SoundEffect>("LOZ_Get_Rupee");
        }

        public void PlayGetRupee()
        {
            if (rupeeSoundInstance == null)
            {
                rupeeSoundInstance = getRupeeMusic.CreateInstance();
            }
            rupeeSoundInstance.Volume = isMuted ? 0f : 1f;
            rupeeSoundInstance.Play();
        }

        public void SetMute(bool mute)
        {
            isMuted = mute;
            if (rupeeSoundInstance != null)
            {
                rupeeSoundInstance.Volume = isMuted ? 0f : 1f;
            }
        }
    }
}
