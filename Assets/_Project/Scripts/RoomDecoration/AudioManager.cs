﻿using UnityEngine;
using System;
using System.Collections.Generic;

public enum SoundType
{
    Music,
    SFX
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public SoundType type;

    [Range(0f, 1f)]
    public float volume = 1f;
    public bool loop = false;

    [HideInInspector] public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sounds")]
    public Sound[] sounds;

    [Header("Volume")]
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;
    public float volumeStep = 0.3f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            float vol = (s.type == SoundType.Music) ? musicVolume : sfxVolume;
            s.source.volume = vol;
        }
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s == null)
        {
            Debug.LogWarning("❌ Sound not found: " + soundName);
            return;
        }

        float vol = (s.type == SoundType.Music) ? musicVolume : sfxVolume;

        if (s.loop)
        {
            if (s.type == SoundType.Music)
            {
                StopAllMusic();
                currentMusicSound = s;
            }

            s.source.Play();
        }
        else
        {
            s.source.PlayOneShot(s.clip, vol);
        }
    }


    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null) return;

        s.source.Stop();
    }

    // ======= BG MUSIC =======

    public void IncreaseMusicVolume()
    {
        musicVolume = Mathf.Clamp01(musicVolume + volumeStep);
        ApplyVolumeByType(SoundType.Music, musicVolume);
        Debug.Log("🔊 Tăng Music Volume: " + musicVolume);
    }

    public void DecreaseMusicVolume()
    {
        musicVolume = Mathf.Clamp01(musicVolume - volumeStep);
        ApplyVolumeByType(SoundType.Music, musicVolume);
        Debug.Log("🔉 Giảm Music Volume: " + musicVolume);
    }

    public void SetMusicVolume(float v)
    {
        musicVolume = Mathf.Clamp01(v);
        ApplyVolumeByType(SoundType.Music, musicVolume);
    }

    private int currentMusicIndex = 0;
    private Sound currentMusicSound;
    public void PlayNextMusic()
    {
        var musicList = GetMusicList();
        if (musicList.Count == 0) return;

        StopAllMusic();

        currentMusicIndex = (currentMusicIndex + 1) % musicList.Count;
        currentMusicSound = musicList[currentMusicIndex];
        currentMusicSound.source.Play();

        Debug.Log($"⏭ Bài tiếp: {currentMusicSound.name}");
    }

    public void PlayPreviousMusic()
    {
        var musicList = GetMusicList();
        if (musicList.Count == 0) return;

        StopAllMusic();

        currentMusicIndex = (currentMusicIndex - 1 + musicList.Count) % musicList.Count;
        currentMusicSound = musicList[currentMusicIndex];
        currentMusicSound.source.Play();

        Debug.Log($"⏮ Bài trước: {currentMusicSound.name}");
    }
    public List<Sound> GetMusicList()
    {
        List<Sound> musicList = new List<Sound>();

        foreach (Sound s in sounds)
        {
            if (s.type == SoundType.Music)
            {
                musicList.Add(s);
            }
        }

        return musicList;
    }
    private void StopAllMusic()
    {
        foreach (var s in sounds)
        {
            if (s.type == SoundType.Music)
                s.source.Stop();
        }
    }

    public Sound GetCurrentMusic()
    {
        return currentMusicSound;
    }



    // ======= SFX =======

    public void IncreaseSFXVolume()
    {
        sfxVolume = Mathf.Clamp01(sfxVolume + volumeStep);
        ApplyVolumeByType(SoundType.SFX, sfxVolume);
        Debug.Log("🔊 Tăng SFX Volume: " + sfxVolume);
    }

    public void DecreaseSFXVolume()
    {
        sfxVolume = Mathf.Clamp01(sfxVolume - volumeStep);
        ApplyVolumeByType(SoundType.SFX, sfxVolume);
        Debug.Log("🔉 Giảm SFX Volume: " + sfxVolume);
    }

    public void SetSFXVolume(float v)
    {
        sfxVolume = Mathf.Clamp01(v);
        ApplyVolumeByType(SoundType.SFX, sfxVolume);
    }

    // ======= APPLY VOLUME =======

    private void ApplyVolumeByType(SoundType type, float volume)
    {
        foreach (var s in sounds)
        {
            if (s.type == type)
            {
                s.source.volume = volume;
            }
        }
    }
}
