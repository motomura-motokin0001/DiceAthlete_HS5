using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DiceController : MonoBehaviour
{
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI angleText;
    private int[] strengthValues = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    private int[] angleValues = { 0, 10, 20, 30, 40, 50, 60, 70, 80 };
    private int strengthIndex = 0;
    private int angleIndex = 0;
    private bool isStrengthSelected = false;
    private bool isAngleSelected = false;

    void Update()
    {
        if (!isStrengthSelected)
        {
            strengthIndex = (strengthIndex + 1) % strengthValues.Length;
            strengthText.text = strengthValues[strengthIndex].ToString();
        }

        if (!isAngleSelected)
        {
            angleIndex = (angleIndex + 1) % angleValues.Length;
            angleText.text = angleValues[angleIndex].ToString();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!isStrengthSelected)
            {
                isStrengthSelected = true;
            }
            else if (!isAngleSelected)
            {
                isAngleSelected = true;
                StartCoroutine(ThrowJavelin());
            }
        }
    }

    IEnumerator ThrowJavelin()
    {
        yield return new WaitForSeconds(1);
        // 槍を投げる処理を呼び出し
        FindObjectOfType<JavelinThrower>().Throw(strengthValues[strengthIndex], angleValues[angleIndex]);
    }
}
