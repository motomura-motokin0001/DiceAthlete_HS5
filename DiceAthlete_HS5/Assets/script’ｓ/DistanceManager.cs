using UnityEngine;
using TMPro;

public class DistanceManager : MonoBehaviour
{
    public static DistanceManager Instance;

    public TextMeshProUGUI resultDistanceText; // ResultScene の距離表示用
    private float finalDistance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン遷移後も保持
        }
        else
        {
            Destroy(gameObject); // 他に同じインスタンスが存在する場合は削除
        }
    }

    public void SetFinalDistance(float distance)
    {
        finalDistance = distance;
    }

    public void DisplayFinalDistance()
    {
        if (resultDistanceText != null)
        {
            resultDistanceText.text = finalDistance.ToString("F2") + "MM";
        }
        else
        {
            Debug.LogError("ResultDistanceText is not assigned.");
        }
        if (resultDistanceText != null)
    {
        resultDistanceText.text = finalDistance.ToString("F2") + "m";
    }
    else
    {
        Debug.LogError("ResultDistanceText is not assigned.");
    }
    }
}
