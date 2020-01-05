using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    // For all sounds
    public List<AudioSource> sounds;

    // For background musics
    public List<AudioSource> musics;

    private void SwitchState(List<AudioSource> list, bool state)
    {
        foreach(AudioSource tmp in list)
        {
            tmp.mute = !state;
        }
    }

    public void OnSoundsToogleChange(Toggle toggle)
    {
        SwitchState(sounds, toggle.isOn);
    }

    public void OnMusicsToogleChange(Toggle toggle)
    {
        SwitchState(musics, toggle.isOn);
    }
}