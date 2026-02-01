using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] GameObject[] gameObjectsToSpawn;
    [SerializeField] int maxNumberObstaclesAtOnce = 5;
    private string obstacleTag = "Obstacle";
    private int obstaclesAdded = 0;

    private float spawnCooldownTimer = 0;
    [SerializeField] float spawnCooldownMin;
    [SerializeField] float spawnCooldownMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnCooldownTimer > 0)
        {
            spawnCooldownTimer -= Time.deltaTime;
        }
        else 
        {
            SpawnObject();
        }
        
        
        // if (gameManager.numberOfObstacles < maxNumberObstaclesAtOnce)
        // {
        //     Debug.Log("Spawning thing!");
        //     SpawnObject();
        //     obstaclesAdded++;
        //     gameManager.numberOfObstacles += 1;
        // }
    }

    float RandomizeSpawnTimer(float min, float max)
    {
        return Random.Range(min, max);
    }

    int RandomizeObject()
    {
        return Random.Range(0, gameObjectsToSpawn.Length);
    }

    void SpawnObject()
    {
        if (gameManager.gameOver == false)
        {
            // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Object.Instantiate.html
            Instantiate(gameObjectsToSpawn[RandomizeObject()], transform.position, Quaternion.identity); 
            spawnCooldownTimer = RandomizeSpawnTimer(spawnCooldownMin, spawnCooldownMax);
        }
    }
}
