using UnityEngine;

public class JavelinCollisionHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isStuck = false;
    private float lastAngle;
    private Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isStuck)
        {
            // 槍の進行方向に基づいて角度を計算し記録
            lastAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isStuck)
        {
            // 槍が地面に衝突した場合
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
            isStuck = true;

            // 槍を地面に固定し、衝突前の角度を適用
            transform.position = collision.contacts[0].point;
            transform.rotation = Quaternion.Euler(0, 0, lastAngle);

            // 距離を計算して記録
            float distance = Vector2.Distance(startPosition, transform.position);

            // // DistanceManager.Instance が null でないか確認
            // if (DistanceManager.Instance != null)
            // {
            //     DistanceManager.Instance.SetFinalDistance(distance);

            //     // リザルトシーンへ遷移
            //     UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            // }
            // else
            // {
            //     Debug.LogError("DistanceManager.Instance is null. Please ensure DistanceManager is in the scene.");
            // }
        }
    }
}
