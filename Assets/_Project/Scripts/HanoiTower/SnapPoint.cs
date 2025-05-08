using Oculus.Interaction;
using System.Linq;
using System.Collections;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public int index;
    public Peg parentPeg;
    public SnapInteractable snapInteractable;

    private Disk currentDisk;
    private bool isLastValid;


    // Lấy Disk hiện tại đang tương tác với SnapPoint
    private void GetCurrentDisk()
    {
        var interactor = snapInteractable.SelectingInteractors.First();
        currentDisk = interactor.GetComponentInParent<Disk>();
    }

    // Được gọi khi Disk snap thành công vào point này
    public void OnDiskSnapped()
    {
        Debug.Log($"Disk snapped to {gameObject.name}");
        GetCurrentDisk();
        if (currentDisk != null)
        {
            //currentDisk.OnInteract(parentPeg, index);
        }
    }

    // Được gọi khi Disk un-snap (nhả ra) từ point này
    public void OnDiskUnsnapped()
    {
        var interactor = snapInteractable.SelectingInteractors.FirstOrDefault();
        if (interactor == null)
            return;
        var disk = interactor.GetComponentInParent<Disk>();
        if (disk != null)
        {
            disk.OnRelease();
        }
    }

    // Kiểm tra khi hover bắt đầu (có thể bật/tắt snapInteractable)
    private void OnInteractorViewAdded()
    {
        GetCurrentDisk();
        var disk = currentDisk.GetComponentInParent<Disk>();
        if (disk == null)
            return;

        // Lấy đĩa ở dưới (nếu index>0)
        Disk belowDisk = null;
        if (index > 0 && parentPeg.snapPoints[index - 1].SelectingInteractors.Count > 0)
        {
            //belowDisk = parentPeg.snapPoints[index - 1].SelectingInteractors[0].GetComponentInParent<Disk>();
        }

        bool isValid = (belowDisk == null || disk.size <= belowDisk.size);
        snapInteractable.MaxSelectingInteractors = isValid ? 1 : 0;
    }

    private void OnInteractorViewRemoved(IInteractorView view)
    {
        // Khôi phục mặc định: chỉ vị trí 0 bật, các vị trí khác tắt
        snapInteractable.MaxSelectingInteractors = (index == 0 ? 1 : 0);
    }

    // Khi bắt đầu snap
    private void OnSnapEnter(IInteractor interactor)
    {
        GetCurrentDisk();
        if (currentDisk == null)
            return;

        // Kiểm tra luật
        Disk topDisk = parentPeg.GetTopDisk();
        isLastValid = (topDisk == null || currentDisk.size <= topDisk.size);

        if (isLastValid)
        {
            OnDiskSnapped();
        }
        else
        {
            StartCoroutine(HandleInvalidSnap());
        }
    }

    private IEnumerator HandleInvalidSnap()
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(currentDisk.transform.position, transform.position) < 0.01f)
        {
            OnDiskSnapped();
        }
        else
        {
            currentDisk.ResetPosition();
        }
    }

    // Khi nhả snap
    private void OnSnapExit(IInteractor interactor)
    {
        OnDiskUnsnapped();
    }
}
