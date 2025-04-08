using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPanel : MonoBehaviour
{
    public GameObject panel;
    public void Display()
    {
        UIManager.Instance.TogglePanel(panel);
    }
}
