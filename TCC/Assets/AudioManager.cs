using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Slider sliderSounds;
    public static float valueSound;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }



    private void Start()
    {
        GeneralVolume();
        Play(EntityTheme());
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) return;

        s.source.Play();
    }


    public void Mute()
    {
        sliderSounds.value = 0;
        valueSound = 0;
    }

    public void UnMute()
    {
        if (valueSound != 0)
            sliderSounds.value = valueSound;
        else
            sliderSounds.value = 0.3f;
    }

    public void GeneralVolume()
    {

        valueSound = sliderSounds.value;
        foreach (Sound s in sounds)
        {
            s.source.volume = sliderSounds.value;
        }

    }

    public string PlayerAttack()
    {
        const string player_Attack = "PlayerAttack";

        return player_Attack;
    }

    public string EntityTheme()
    {
        const string Entity_Theme = "EntityTheme";

        return Entity_Theme;
    }

    public string Ferreiro()
    {
        const string FerreiroS = "Ferreiro";

        return FerreiroS;
    }
}
