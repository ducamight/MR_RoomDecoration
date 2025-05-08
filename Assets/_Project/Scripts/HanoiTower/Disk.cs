using UnityEngine;

public class Disk : MonoBehaviour
{
    public int size; // 1 là nhỏ nhất
    public Peg currentPeg;
    public Vector3 originalPosition;

    private void Start()
    {
        // Lưu vị trí ban đầu để reset khi cần
        originalPosition = transform.position;
    }

    // Gọi khi Disk đã snap thành công vào một SnapPoint
    public void OnSnapped(Peg peg, int index)
    {
        Debug.Log($"[Snapped] Disk {size} → Peg {peg.name} @ index {index}");
        currentPeg = peg;
        originalPosition = transform.position;

        // Bật snapPoint tiếp theo để cho phép đặt đĩa tiếp
        peg.SetSnapPointActive(index + 1, true);
    }

    // Gọi khi Disk được un-snap (nhả ra)
    public void OnRelease()
    {
        // Nếu cần, thêm logic xử lý khi release (ví dụ tắt hiệu ứng)
        Debug.Log($"[Released] Disk {size} released from Peg {currentPeg?.name}");
    }

    // Đưa Disk về vị trí ban đầu
    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}
