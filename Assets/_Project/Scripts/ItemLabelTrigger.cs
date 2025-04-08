using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLabelTrigger : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform spawnPoint;

    public void OnLabelPressed()
    {
        if (itemPrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("⚠️ Thiếu prefab hoặc điểm spawn.");
            return;
        }
        itemPrefab.SetActive(true);
        //GameObject spawned = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log($"✨ Spawned");
    }
}
