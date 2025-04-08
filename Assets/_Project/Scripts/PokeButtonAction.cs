using UnityEngine;

public class PokeButtonAction : MonoBehaviour
{
    public enum ActionType
    {
        IncreaseMusicVolume,
        DecreaseMusicVolume,
        IncreaseSFXVolume,
        DecreaseSFXVolume,
        NextMusic,
        PreviousMusic
    }

    [Header("Chọn hành động khi Poke")]
    public ActionType actionType;

    public void ExecuteAction()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("❌ AudioManager is not init!");
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

            case ActionType.NextMusic:
                AudioManager.Instance.PlayNextMusic(); 
                break;
            case ActionType.PreviousMusic:
                AudioManager.Instance.PlayPreviousMusic();
                break;

        }
    }
}
