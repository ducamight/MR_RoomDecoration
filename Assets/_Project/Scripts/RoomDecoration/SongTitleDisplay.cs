using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongTitleDisplay : MonoBehaviour
{
    [Header("UI Hiển thị tên bài hát")]
    public TextMeshPro uiText; // nếu dùng Text thường

    [Tooltip("Tần suất cập nhật (giây)")]
    public float refreshInterval = 0.5f;

    private float timer = 0f;
    private string currentTitle = "";

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= refreshInterval)
        {
            timer = 0f;
            UpdateSongTitle();
        }
    }

    private void UpdateSongTitle()
    {
        var currentMusic = GetCurrentMusicPlaying();
        if (currentMusic != null)
        {
            string name = currentMusic.name;

            if (name != currentTitle)
            {
                currentTitle = name;
                if (uiText != null) uiText.text = name;
            }
        }
    }

    private Sound GetCurrentMusicPlaying()
    {
        if (AudioManager.Instance == null) return null;

        foreach (var s in AudioManager.Instance.sounds)
        {
            if (s.type == SoundType.Music && s.source.isPlaying)
            {
                return s;
            }
        }

        return null;
    }
}
