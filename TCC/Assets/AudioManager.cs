using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Slider sliderSounds;
    public static float valueSound;

    public static bool canChange = false;
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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Play(EntityTheme());
        }
        GeneralVolume();
    }

    private void Update()
    {
        if (canChange)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Play(Ferreiro());
                Stop(Forest());
                canChange = false;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Play(Forest());
                Stop(Ferreiro());
                canChange = false;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) return;

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) return;

        s.source.Stop();
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

    public string Forest()
    {
        const string ForestS = "Forest";

        return ForestS;
    }
}
