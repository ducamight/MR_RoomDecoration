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
    private Rigidbody rb;
    private MeshCollider meshCollider;  
    private BoxCollider boxCollider;
    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>(true);
        itemUIImage = itemUI.GetComponentInChildren<Image>();
        rb = GetComponentInChildren<Rigidbody>();
        meshCollider = GetComponentInChildren<MeshCollider>();
        boxCollider = GetComponentInChildren<BoxCollider>();
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
            rb.isKinematic = false;
            rb.useGravity = true;
            meshCollider.enabled = true;
            boxCollider.enabled = false;
        }
        itemUI.SetActive(false);
    }
}
