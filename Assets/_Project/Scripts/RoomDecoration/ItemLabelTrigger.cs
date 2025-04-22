using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLabelTrigger : MonoBehaviour
{
    public GameObject itemPrefab;
    [SerializeField] private string prefabName = "ItemPrefab";
    public Transform spawnPoint;

    private void Start()
    {
        if (itemPrefab == null)
        {
            itemPrefab = GameObject.Find(prefabName);

            if (itemPrefab == null)
                Debug.LogWarning("Cant find itemPrefab after reload scene.");
        }

        if (spawnPoint == null)
        {
            spawnPoint = GameObject.Find("SpawnPoint").transform;

            if (itemPrefab == null)
                Debug.LogWarning("Cant find spawnPoint after reload scene.");
        }
    }
    public void OnLabelPressed()
    {
        if (itemPrefab == null || spawnPoint == null)
        {
            return;
        }
        itemPrefab.SetActive(true);
        AudioManager.Instance.Play("SpawnItem");
        //GameObject spawned = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);

    }
}
