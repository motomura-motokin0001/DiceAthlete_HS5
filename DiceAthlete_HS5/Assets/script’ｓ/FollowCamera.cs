using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // 追いかける対象（槍）
    public float smoothSpeed = 0.125f; // スムーズな追従のための速度
    public Vector3 offset; // カメラと槍の相対位置

    void FixedUpdate()
    {
        if (target != null)
        {
            // ターゲットの位置にカメラの位置を合わせる
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // カメラの向きをターゲットに向ける
            transform.LookAt(target);
        }
    }
}
