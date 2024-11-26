using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // 追従する対象（槍）
    public float smoothSpeed = 0.125f; // カメラの追従速度
    public Vector3 offset; // カメラのオフセット

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
