using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicButtonUI : MonoBehaviour
{
    [Header("Icon hiển thị")]
    public GameObject playIcon;   
    public GameObject pauseIcon; 

    private bool isPlaying = true;

    void Start()
    {
        UpdateUI();
    }

    public void ToggleMusic()
{
        if (AudioManager.Instance == null) return;

        var current = AudioManager.Instance.GetCurrentMusic();

        if (current != null)
        {
            if (current.source.isPlaying){
                isPlaying = false;
                current.source.Pause();
            }
            else
            {
                isPlaying = true;
                current.source.Play();
            }
        }
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (playIcon != null) playIcon.SetActive(!isPlaying);
        if (pauseIcon != null) pauseIcon.SetActive(isPlaying);
    }
}
