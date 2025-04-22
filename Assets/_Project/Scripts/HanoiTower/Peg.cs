using Oculus.Interaction;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    public List<SnapInteractable> snapPoints; // Gắn thủ công từ dưới lên trên trong Editor

    public void SetSnapPointActive(int index, bool isActive)
    {
        if (index >= 0 && index < snapPoints.Count)
        {
            snapPoints[index].MaxSelectingInteractors = isActive ? 1 : 0;
        }
    }

    public int GetTopDiskIndex()
    {
        for (int i = snapPoints.Count - 1; i >= 0; i--)
        {
            if (snapPoints[i].SelectingInteractors.Count > 0)
            {
                Debug.Log("Index of top disk: " + i + " in peg " + gameObject.name + " is: " + snapPoints[i]);
                return i;
            }
        }
        return -1;
    }

    public Disk GetTopDisk()
    {
        int idx = GetTopDiskIndex();
        return idx != -1 ? snapPoints[idx].GetComponentInChildren<Disk>() : null;
    }
}
