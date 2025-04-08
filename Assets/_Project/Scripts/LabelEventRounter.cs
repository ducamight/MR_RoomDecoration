using UnityEngine;

public class LabelEventRouter : MonoBehaviour
{
    public void OnAnyLabelPressed()
    {
        // Duyệt qua các label con để tìm cái nào đang active (tuỳ em muốn xử lý kiểu gì)
        foreach (Transform child in transform)
        {
            var label = child.GetComponent<ItemLabelTrigger>();
            if (label != null)
            {
                label.OnLabelPressed();
                break; // chỉ 1 label được nhấn
            }
        }
    }
}