using UnityEngine;

public class SnapZoneManager : MonoBehaviour
{
    [Header("SnapZoneCollider")]
    public GameObject floorZonesRoot;
    public GameObject wallZonesRoot;

    private void Awake()
    {
        if (floorZonesRoot != null) floorZonesRoot.SetActive(false);
        if (wallZonesRoot != null) wallZonesRoot.SetActive(false);
    }
    public void EnableFloorZones()
    {
        if (floorZonesRoot != null) floorZonesRoot.SetActive(true);
        if (wallZonesRoot != null) wallZonesRoot.SetActive(false);
    }

    public void EnableWallZones()
    {
        if (wallZonesRoot != null) wallZonesRoot.SetActive(true);
        if (floorZonesRoot != null) floorZonesRoot.SetActive(false);
    }

    public void DisableAllZones()
    {
        if (floorZonesRoot != null) floorZonesRoot.SetActive(false);
        if (wallZonesRoot != null) wallZonesRoot.SetActive(false);
    }
}

