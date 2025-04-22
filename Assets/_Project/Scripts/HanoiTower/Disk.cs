using UnityEngine;

public class Disk : MonoBehaviour
{
    public int size; // 1 là nhỏ nhất
    public Peg currentPeg;
    public Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void OnInteract(Peg peg, int index)
    {
        Debug.Log($"Disk {size} snapped to peg {peg.name} at index {index}");
        currentPeg = peg;

        // Kiểm tra tính hợp lệ
        var topDisk = peg.GetTopDisk();
        if (topDisk != null && topDisk != this && size > topDisk.size)
        {
            Debug.Log("Invalid move: Disk {size} cannot be placed on Disk {topDisk.size}.");
            // Sai luật → reset về vị trí cũ
            Invoke(nameof(ResetPosition), 0.5f);
        }
        else
        {
            Debug.Log("Valid move: Disk {size} cannot be placed on Disk {topDisk.size}.");

            // Đúng luật → bật snapPoint tiếp theo
            peg.SetSnapPointActive(index + 1, true);
            originalPosition = transform.position;
        }
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}
