using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] GameObject gameObjectToSpawn;
    [SerializeField] int maxNumberObstaclesAtOnce = 5;
    [SerializeField] float minSecondsObstacleSpawn = 10.0f;
    [SerializeField] float maxSecondsObstacleSpawn = 15.0f;
    private string obstacleTag = "Obstacle";
    private int obstaclesAdded = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // for (int i = 0; i < maxNumberObstaclesAtOnce; i++)
        // {
        //     // float randomTime = Random.Range(minSecondsObstacleSpawn, maxSecondsObstacleSpawn);
        //     // Invoke("SpawnObject", randomTime);
        //     SpawnObject();
        //     obstaclesAdded++;

        //     // Game manager number:
        //     gameManager.numberOfObstacles += obstaclesAdded;
        // }
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.numberOfObstacles < maxNumberObstaclesAtOnce)
        {
            Debug.Log("Spawning thing!");
            SpawnObject();
            obstaclesAdded++;
            gameManager.numberOfObstacles += 1;
        }
    }

    void SpawnObject()
    {
        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Object.Instantiate.html
        Instantiate(gameObjectToSpawn, transform.position, Quaternion.identity);
    }
}
