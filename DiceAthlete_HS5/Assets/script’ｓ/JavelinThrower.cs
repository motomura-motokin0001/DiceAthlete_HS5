using UnityEngine;
using TMPro;

public class JavelinThrower : MonoBehaviour
{
    public GameObject javelin;
    public Transform throwPoint;
    public CameraFollow2D cameraFollow; // カメラ追従スクリプトの参照
    public TextMeshProUGUI distanceText; // 距離表示用のTextMeshPro

    private GameObject currentJavelin;
    private Vector2 startPosition;

    public void Throw(int strength, int angle)
    {
        // 槍のインスタンスを作成
        currentJavelin = Instantiate(javelin, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = currentJavelin.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // 強さと角度に基づいて力を加える
            float radianAngle = angle * Mathf.Deg2Rad;
            Vector2 force = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle)) * strength;
            rb.AddForce(force, ForceMode2D.Impulse);

            // カメラのターゲットを新しい槍に設定
            if (cameraFollow != null)
            {
                cameraFollow.target = currentJavelin.transform;
            }

            // 槍の飛行距離表示のために開始位置を記録
            startPosition = throwPoint.position;
        }
        else
        {
            Debug.LogError("Rigidbody2D component is missing on the javelin prefab.");
        }
    }

    void Update()
    {
        if (currentJavelin != null)
        {
            // 飛んでいる距離を計算して表示
            float distance = Vector2.Distance(startPosition, currentJavelin.transform.position);
            distanceText.text = distance.ToString("F2") + "M";
        }
    }
}
