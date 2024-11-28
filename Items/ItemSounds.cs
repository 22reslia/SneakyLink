using Microsoft.Xna.Framework.Audio;

namespace SneakyLink.Items;

public class ItemSounds
{   
    private SoundEffect getRupeeMusic;
    public void LoadItemSoundEffects(Game1 game)
    {
        getRupeeMusic = game.Content.Load<SoundEffect>("LOZ_Get_Rupee");
    }
    public void PlayGetRupee()
    {   
        // Create a new instance every time the method is called
        var rupeeSoundInstance = getRupeeMusic.CreateInstance();
        rupeeSoundInstance.Volume = 1f; // Set volume as desired
        rupeeSoundInstance.IsLooped = false;
        rupeeSoundInstance.Play();
    }
}

