using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    private GameObject spawnTransform;


    private void Start()
    {
        spawnTransform = GameObject.Find("SpawnTransform");
    }

    public void Spawn()
    {
        transform.position = spawnTransform.transform.position;
    }
}
