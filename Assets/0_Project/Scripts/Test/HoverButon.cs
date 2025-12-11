using UnityEngine;
using UnityEngine.EventSystems;

public class HoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleUp = 1.1f;        // phóng to khi hover
    public float smoothTime = 0.08f;    // thời gian mượt
    private Vector3 currentVelocity;    // dùng cho SmoothDamp
    private Vector3 targetScale;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        // SmoothDamp tự động làm chuyển động siêu mượt
        transform.localScale = Vector3.SmoothDamp(
            transform.localScale,
            targetScale,
            ref currentVelocity,
            smoothTime
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = originalScale * scaleUp;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
    }
}
