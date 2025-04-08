using UnityEngine;
using UnityEngine.UI;

public class SFXVolumeIcon : MonoBehaviour
{
    [Header("Image UI để hiển thị icon")]
    public Image volumeImage;

    [Header("Các mức độ âm lượng")]
    public Sprite muteIcon;
    public Sprite lowIcon;
    public Sprite mediumIcon;
    public Sprite highIcon;

    [Tooltip("Tần suất cập nhật (giây)")]
    public float refreshInterval = 0.25f;

    private float timer = 0f;
    private float lastVolume = -1f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= refreshInterval)
        {
            timer = 0f;

            float vol = AudioManager.Instance != null ? AudioManager.Instance.sfxVolume : 0f;

            if (Mathf.Abs(vol - lastVolume) > 0.01f)
            {
                UpdateVolumeIcon(vol);
                lastVolume = vol;
            }
        }
    }

    private void UpdateVolumeIcon(float volume)
    {
        if (volumeImage == null) return;

        if (volume <= 0.01f)
        {
            volumeImage.sprite = muteIcon;
        }
        else if (volume <= 0.33f)
        {
            volumeImage.sprite = lowIcon;
        }
        else if (volume <= 0.66f)
        {
            volumeImage.sprite = mediumIcon;
        }
        else
        {
            volumeImage.sprite = highIcon;
        }
    }
}