using UnityEngine;

public class BGMusicManager : MonoBehaviour
{
    public static BGMusicManager Instance;

    [Header("Âm thanh")]
    public AudioClip[] backgroundMusic;
    public int currentTrackIndex = 0;

    [Header("Âm lượng")]
    [Range(0f, 1f)] public float volume = 0.5f;
    public float volumeStep = 0.1f;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Setup AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        PlayCurrentTrack();
    }

    public void PlayCurrentTrack()
    {
        if (backgroundMusic.Length == 0 || backgroundMusic[currentTrackIndex] == null)
        {
            Debug.LogWarning("🎵 Không có track để phát!");
            return;
        }

        audioSource.clip = backgroundMusic[currentTrackIndex];
        audioSource.volume = volume;
        audioSource.Play();
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void IncreaseVolume()
    {
        volume = Mathf.Clamp(volume + volumeStep, 0f, 1f);
        audioSource.volume = volume;
    }

    public void DecreaseVolume()
    {
        volume = Mathf.Clamp(volume - volumeStep, 0f, 1f);
        audioSource.volume = volume;
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        audioSource.volume = volume;
    }
}
