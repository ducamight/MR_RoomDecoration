using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSnapToParent : MonoBehaviour
{
    public Transform decorGroupRoot;
    public void OnSnapComplete()
    {
        transform.SetParent(decorGroupRoot);
    }
}
