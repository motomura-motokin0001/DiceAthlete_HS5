using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        float distance = PlayerPrefs.GetFloat("ThrowDistance");
        resultText.text = distance.ToString("F2") + " meters";
    }
}
