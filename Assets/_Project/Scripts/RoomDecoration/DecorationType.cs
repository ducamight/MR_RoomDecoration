using UnityEngine;
using Oculus.Interaction;
using System.Collections;
using Oculus.Interaction.HandGrab;
using System;
using Unity.VisualScripting;

public enum DecorationTypeEnum
{
    Floor,
    Wall,
    None
}
public class DecorationType : MonoBehaviour
{
    private SnapZoneManager snapZoneManager;

    
    public DecorationTypeEnum type;

    public string FloorTag = "Floor";
    public string WallTag = "Wall";
    public string NoneTag = "None";

    public Action onSelect;
    public Action onUnSelect;

    private void Awake()
    {
        snapZoneManager = FindObjectOfType<SnapZoneManager>();
        if (type == DecorationTypeEnum.Floor)
        {
            gameObject.tag = FloorTag;
        }
        else if (type == DecorationTypeEnum.Wall)
        {
            gameObject.tag = WallTag;
        }
        else
        {
            gameObject.tag = NoneTag;
        }
    }

    public void OnSelect()
    {
        Debug.Log("Selected");
        if (gameObject.CompareTag("Floor"))
        {
            snapZoneManager.EnableFloorZones();
        }
        else if (gameObject.CompareTag("Wall"))
        {
            snapZoneManager.EnableWallZones();
        }
        else
        {
            snapZoneManager.DisableAllZones();
        }
    }
    public void OnUnSelect()
    {
        StartCoroutine(WaitForUnSelect());
    }

    IEnumerator WaitForUnSelect()
    {
        yield return new WaitForSeconds(0.2f);
        snapZoneManager.DisableAllZones();
    }
}
