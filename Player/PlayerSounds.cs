using Microsoft.Xna.Framework.Audio;

namespace SneakyLink.Player
{
    public class PlayerSounds
    {
        private SoundEffect linkSwordSlashMusic;
        private SoundEffect linkHurtMusic;
        private SoundEffectInstance linkSwordSlashSound;
        private SoundEffectInstance linkHurtInstance;
        private bool isMuted = false; // Tracks the mute state

        public void LoadPlayerSoundEffects(Game1 game)
        {
            linkSwordSlashMusic = game.Content.Load<SoundEffect>("LOZ_Sword_Slash");
            linkHurtMusic = game.Content.Load<SoundEffect>("LOZ_Link_Hurt");
        }

        public void PlayLinkSwordSlash()
        {
            if (linkSwordSlashSound == null)
            {
                linkSwordSlashSound = linkSwordSlashMusic.CreateInstance();
            }
            linkSwordSlashSound.Volume = isMuted ? 0f : 1f;
            linkSwordSlashSound.Play();
        }

        public void PlayLinkHurt()
        {
            if (linkHurtInstance == null)
            {
                linkHurtInstance = linkHurtMusic.CreateInstance();
            }
            linkHurtInstance.Volume = isMuted ? 0f : 1f;
            linkHurtInstance.Play();
        }

        public void SetMute(bool mute)
        {
            isMuted = mute;
            if (linkSwordSlashSound != null)
            {
                linkSwordSlashSound.Volume = isMuted ? 0f : 1f;
            }
            if (linkHurtInstance != null)
            {
                linkHurtInstance.Volume = isMuted ? 0f : 1f;
            }
        }
    }
}
