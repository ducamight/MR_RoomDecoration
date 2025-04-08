using UnityEngine;

public class PokeButtonAction : MonoBehaviour
{
    public enum ActionType
    {
        IncreaseMusicVolume,
        DecreaseMusicVolume,
        IncreaseSFXVolume,
        DecreaseSFXVolume,
        ToggleMusic,
        NextMusic
    }

    [Header("Chọn hành động khi Poke")]
    public ActionType actionType;

    public void ExecuteAction()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("❌ AudioManager chưa khởi tạo!");
            return;
        }

        switch (actionType)
        {
            case ActionType.IncreaseMusicVolume:
                AudioManager.Instance.IncreaseMusicVolume();
                break;

            case ActionType.DecreaseMusicVolume:
                AudioManager.Instance.DecreaseMusicVolume();
                break;

            case ActionType.IncreaseSFXVolume:
                AudioManager.Instance.IncreaseSFXVolume();
                break;

            case ActionType.DecreaseSFXVolume:
                AudioManager.Instance.DecreaseSFXVolume();
                break;

            case ActionType.ToggleMusic:
                ToggleMusicPlay();
                break;

            case ActionType.NextMusic:
                //AudioManager.Instance.PlayNextMusic(); // Cần thêm trong AudioManager
                break;
        }
    }

    private void ToggleMusicPlay()
    {
        foreach (var s in AudioManager.Instance.sounds)
        {
            if (s.type == SoundType.Music)
            {
                if (s.source.isPlaying)
                    s.source.Pause();
                else
                    s.source.Play();

                break;
            }
        }
    }
}
