using Oculus.Interaction.HandGrab;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabItemFromUI : MonoBehaviour
{
    private MeshRenderer[] meshRenderers;
    public GameObject itemUI;

    private Image itemUIImage;


    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>(true);
        itemUIImage = itemUI.GetComponentInChildren<Image>();
    }

    public void OnHover()
    {
        Debug.Log("Hover");
        itemUIImage.color = new Color(1, 1, 1, 0.5f);
    }
    public void OnUnhover()
    {
        itemUIImage.color = new Color(1, 1, 1, 1);
    }
    public void Ongrab()
    {
        foreach (var renderer in meshRenderers)
        {
            renderer.enabled = true;
        }
        itemUI.SetActive(false);
    }
}
