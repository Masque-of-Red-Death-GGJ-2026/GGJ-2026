using UnityEngine;

public class DestroyObstacleOutOfView : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] Vector2 moveObstacleVector = new Vector2(5.0f, 0.0f);
    [SerializeField] Vector2 target = new Vector2(-11.0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards player:
        float step = 1.0f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        // If object out of view, destroy:
        if (gameObject.transform.position.x <= -11)
        {
            Destroy(gameObject);

            // Tell game manager number reduced:
            gameManager.numberOfObstacles--;
        }
    }
}
