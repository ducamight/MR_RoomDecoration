using Oculus.Interaction.HandGrab;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemFromUI : MonoBehaviour
{
    private MeshRenderer[] meshRenderers;
    Rigidbody rb;
    public GameObject itemUI;

    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>(true);
        rb = GetComponentInChildren<Rigidbody>();


    }
    public void Ongrab()
    {
        foreach (var renderer in meshRenderers)
        {
            renderer.enabled = true;
        }
        rb.useGravity = true;
        rb.isKinematic = false;
        Destroy(itemUI, 0.5f);
    }
}
