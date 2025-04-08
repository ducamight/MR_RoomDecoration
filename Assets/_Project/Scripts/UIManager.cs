using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject[] allPanels;

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

    public void TogglePanel(GameObject panel)
    {
        if (panel == null) return;

        bool isActive = panel.activeSelf;
        panel.SetActive(!isActive);
    }
}
