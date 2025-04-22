using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPanel : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private string panelName = "ShopPanel";

    private void Start()
    {
        if (panel == null)
        {
            panel = GameObject.Find(panelName);
            if (panel == null)
            {
                Debug.LogWarning("⚠️ Panel không tìm thấy sau khi restart scene.");
            }
        }
    }
    public void Display()
    {
        UIManager.Instance.TogglePanel(panel);
    }
}
