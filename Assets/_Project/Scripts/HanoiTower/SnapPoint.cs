using UnityEngine;
using Oculus.Interaction;
using System.Linq;

public class SnapPoint : MonoBehaviour
{
    public int index;
    public Peg parentPeg;
    public SnapInteractable snapInteractable;

    private Disk currentDisk;
    private void GetCurrentDisk()
    {
        var interactor = snapInteractable.SelectingInteractors.First();

        currentDisk = interactor.GetComponentInParent<Disk>();
    }
    public void OnDiskSnapped()
    {
        Debug.Log($"Disk snapped to {gameObject.name}");

        GetCurrentDisk();
        
        if (currentDisk != null)
        {
            currentDisk.OnInteract(parentPeg, index);
        }
    }
}
