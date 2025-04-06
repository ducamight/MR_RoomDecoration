using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeButtonAction : MonoBehaviour
{
    [Header("Prefab to spawn")]
    public GameObject objectToSpawn;

    [Header("Spawn position")]
    public Transform spawnPoint;
    public void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
            Debug.Log("✅ Đã spawn object: " + objectToSpawn.name);
        }
    }
}
