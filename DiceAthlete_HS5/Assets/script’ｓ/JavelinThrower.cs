using UnityEngine;

public class JavelinThrower : MonoBehaviour
{
    public GameObject javelin;
    public Transform throwPoint;

    public void Throw(int strength, int angle)
    {
        GameObject newJavelin = Instantiate(javelin, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = newJavelin.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float radianAngle = angle * Mathf.Deg2Rad;
            Vector2 force = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle)) * strength;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody2D component is missing on the javelin prefab.");
        }
    }
}
