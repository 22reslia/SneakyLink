using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;

public class PlayerSounds
{   
    private SoundEffect linkSwordSlashMusic;
    private SoundEffectInstance linkSwordSlashSound;
    private SoundEffect linkHurtMusic;
    public void LoadPlayerSoundEffects(Game1 game)
    {
        linkSwordSlashMusic = game.Content.Load<SoundEffect>("LOZ_Sword_Slash");
        linkHurtMusic = game.Content.Load<SoundEffect>("LOZ_Link_Hurt");
    }
    public void PlayLinkSwordSlash()
    {   
        // Ensure the sound instance is initialized
        if (linkSwordSlashSound == null)
        {
        linkSwordSlashSound = linkSwordSlashMusic.CreateInstance();
        linkSwordSlashSound.Volume = 1f;
        linkSwordSlashSound.IsLooped = false;
        }

        // Play only if not already playing
        if (linkSwordSlashSound.State != SoundState.Playing)
        {
            linkSwordSlashSound.Play();
        }
    }

    public void PlayLinkHurt()
    {
        // Create a new instance every time the method is called
        var linkHurtInstance = linkHurtMusic.CreateInstance();
        linkHurtInstance.Volume = 1f; // Set volume as desired
        linkHurtInstance.IsLooped = false;
        linkHurtInstance.Play();
    }
}

