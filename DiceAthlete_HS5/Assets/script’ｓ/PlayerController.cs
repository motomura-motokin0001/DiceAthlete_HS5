// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public GameObject javelinPrefab;
//     public Transform throwPoint;
//     public float throwDelay = 1f; // 槍を投げるまでの待機時間

//     private GameObject currentJavelin;
//     private JavelinRotationController2D javelinRotationController;
//     private bool isHoldingJavelin = false;
//     private float angle = 0f; // 初期角度

//     void Update()
//     {
//         if (isHoldingJavelin)
//         {
//             // 角度変更
//             if (Input.GetAxis("Horizontal") != 0)
//             {
//                 angle += Input.GetAxis("Horizontal") * Time.deltaTime * 100f; // 左右の入力で角度変更
//             }

//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 ThrowJavelin();
//             }
//         }
//     }

//     public void PickupJavelin()
//     {
//         if (!isHoldingJavelin)
//         {
//             currentJavelin = Instantiate(javelinPrefab, throwPoint.position, Quaternion.identity);
//             currentJavelin.transform.parent = transform; // プレイヤーの子オブジェクトとして設定
//             javelinRotationController = currentJavelin.GetComponent<JavelinRotationController2D>();
//             isHoldingJavelin = true;
//         }
//     }

//     private void ThrowJavelin()
//     {
//         if (currentJavelin != null)
//         {
//             currentJavelin.transform.parent = null; // プレイヤーから切り離す
//             javelinRotationController.enabled = true; // 回転スクリプトを有効にする

//             DiceController diceController = FindObjectOfType<DiceController>();
//             if (diceController != null)
//             {
//                 int strength = diceController.GetStrength(); // DiceControllerから強さを取得
//                 int angle = diceController.GetAngle(); // DiceControllerから角度を取得
//                 JavelinThrower thrower = currentJavelin.GetComponent<JavelinThrower>();
//                 thrower.Throw(strength, angle);
//             }

//             isHoldingJavelin = false;
//             currentJavelin = null;

//             // 一定時間後に槍を削除（必要に応じて）
//             Destroy(currentJavelin, throwDelay);
//         }
//     }
// }
