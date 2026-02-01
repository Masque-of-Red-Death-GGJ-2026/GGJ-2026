using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] Vector2 moveObstacleVector = new Vector2(5.0f, 0.0f);
    [SerializeField] Vector2 target = new Vector2(-11.0f, 0.0f);
    private float speed = 5;

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
        transform.position += new Vector3(-1, 0) * speed * Time.deltaTime;
        
        // Check if overlaping with obstacle (if found, destroy):
        foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (gameObject.transform.position.x == obstacle.transform.position.x)
            {
                Destroy(gameObject);
            }
        }

        // If object out of view, destroy:
        if (gameObject.transform.position.x <= -11)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Add points via GameManager:
            gameManager.currentScore++;
            gameManager.GameScoreTextUI.text = gameManager.currentScore.ToString();
            Destroy(gameObject);
        }
    }
}
