using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;

public class PlayerSounds
{   
    private SoundEffect linkSwordSlashMusic;
    private SoundEffectInstance linkSwordSlashSound;
    public void LoadPlayerSoundEffects(Game1 game)
    {
        linkSwordSlashMusic = game.Content.Load<SoundEffect>("LOZ_Sword_Slash");
    }
    public void PlayLinkSwordSlash()
    {   
        // Ensure the sound instance is initialized
        if (linkSwordSlashSound == null)
        {
        linkSwordSlashSound = linkSwordSlashMusic.CreateInstance();
        linkSwordSlashSound.Volume = 0.5f;
        linkSwordSlashSound.IsLooped = false;
        }

        // Play only if not already playing
        if (linkSwordSlashSound.State != SoundState.Playing)
        {
            linkSwordSlashSound.Play();
        }
    }
}

