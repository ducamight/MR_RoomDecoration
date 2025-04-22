using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePassthrough : MonoBehaviour
{
    [Header("🎥 Camera cần đổi clear mode")]
    [SerializeField] private Camera targetCamera;

    [Header("🌈 Passthrough Layer")]
    [SerializeField] private OVRPassthroughLayer passthroughLayer;

    [Header("⚙️ Settings")]
    [SerializeField] private Color solidColor = Color.black;

    private bool isPassthroughOn = false;

    private void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        if (passthroughLayer == null)
            passthroughLayer = FindObjectOfType<OVRPassthroughLayer>();

        // Khởi động với passthrough đang bật
        OnEnablePassthrough();
    }

    public void TogglePassthrough()
    {
        if (isPassthroughOn)
            DisablePassthrough();
        else
            OnEnablePassthrough();
    }

    public void OnEnablePassthrough()
    {
            isPassthroughOn = true;

            if (passthroughLayer != null)
            {
                passthroughLayer.enabled = true;
                passthroughLayer.gameObject.SetActive(true);
            }

            if (targetCamera != null)
            {
                // ✅ Quan trọng: để passthrough hiện đúng
                targetCamera.clearFlags = CameraClearFlags.Depth;
                targetCamera.backgroundColor = Color.clear;
            }

            Debug.Log("✅ Passthrough Enabled");
    }

    public void DisablePassthrough()
    {
        isPassthroughOn = false;

        if (passthroughLayer != null)
        {
            passthroughLayer.enabled = false;
            passthroughLayer.gameObject.SetActive(false);
        }

        if (targetCamera != null)
        {
            // ✅ Chuyển về Skybox
            targetCamera.clearFlags = CameraClearFlags.Skybox;

            // ✅ Đảm bảo skybox đang được renderSettings gán
            if (RenderSettings.skybox == null)
            {
                Debug.LogWarning("⚠️ RenderSettings.skybox chưa được gán!");
            }
        }

        Debug.Log("❌ Passthrough Disabled → chuyển về Skybox");
    }
}
