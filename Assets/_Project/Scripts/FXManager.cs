using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void PlayFX(GameObject fxPrefab, Vector3 position, float duration)
    {
        Debug.Log("Play FX");

        if (fxPrefab == null)
        {
            Debug.LogWarning("❌ FX prefab chưa gán!");
            Debug.Log("Play FX: " + fxPrefab.name + " at position: " + position);

            return;
        }

        GameObject fx = Instantiate(fxPrefab, position, Quaternion.identity);
        Destroy(fx, duration);
    }
}
