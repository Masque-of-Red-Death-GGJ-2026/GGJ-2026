using UnityEngine;

public class DestroyObstacleOutOfView : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If object out of view, destroy:
        if (gameObject.transform.position.x <= -11)
        {
            Destroy(gameObject);
        }
    }
}
