using Oculus.Interaction;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    public List<SnapInteractable> snapPoints;

    private void Start()
    {
        // Luôn cho phép snap vào vị trí 0
        for (int i = 0; i < snapPoints.Count; i++)
        {
            snapPoints[i].MaxSelectingInteractors = (i == 0) ? 1 : 0;
        }
    }
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
                Debug.Log($"Index of top disk: {i} in peg {gameObject.name}");
                // Khi phát hiện đĩa trên snapPoint i, bật snapPoint i+1
                SetSnapPointActive(i + 1, true);
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