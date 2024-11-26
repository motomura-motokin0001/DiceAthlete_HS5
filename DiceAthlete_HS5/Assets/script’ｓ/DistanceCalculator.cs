using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DistanceCalculator : MonoBehaviour
{
    public Transform throwPoint;
    public TextMeshProUGUI resultText;
    private Vector3 javelinStartPoint;

    void Start()
    {
        javelinStartPoint = throwPoint.position;
    }

    public void CalculateDistance(Vector3 javelinEndPoint)
    {
        float distance = Vector3.Distance(javelinStartPoint, javelinEndPoint);
        PlayerPrefs.SetFloat("ThrowDistance", distance);
        SceneManager.LoadScene("Result");
    }
}
