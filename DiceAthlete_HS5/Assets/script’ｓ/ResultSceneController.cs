using UnityEngine;

public class ResultSceneController : MonoBehaviour
{
    void Start()
    {
        if (DistanceManager.Instance != null)
        {
            DistanceManager.Instance.DisplayFinalDistance();
        }
        else
        {
            Debug.LogError("DistanceManager.Instance is null. Please ensure DistanceManager is in the scene.");
        }
    }
}
