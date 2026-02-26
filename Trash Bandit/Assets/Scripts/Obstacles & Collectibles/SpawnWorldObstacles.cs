using UnityEngine;

public class SpawnWorldObstacles : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] GameObject gameObjectToSpawn;
    private float spawnCooldownTimer = 0;
    [SerializeField] float spawnCooldownMin;
    [SerializeField] float spawnCooldownMax;
    
    [SerializeField] float spawnRadius = 5f;
    [SerializeField] float checkRadius = 1f; 

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
            CheckForConflict();
        }
    }

    float RandomizeSpawnTimer(float min, float max)
    {
        return Random.Range(min, max);
    }

    void CheckForConflict() {
        Vector3 spawnPosition = Vector3.zero;
        bool canSpawn = false;

        while (!canSpawn && gameManager.gameOver == false) {
            // choose a new random position
            Vector2 newPosition = new Vector2(transform.position.x + Random.Range(0.0f, 0.005f), transform.position.y);
            // Check there are any box colliders within a circle around it, if so keep the position and spawn 
            if (!Physics.CheckSphere(newPosition, checkRadius)) {
                canSpawn = true;
                spawnPosition = newPosition;
            }
            // if space is not clear then repeat with a new position
        }
        // spawn object in clear space
        if (canSpawn) {
            SpawnObject(spawnPosition);
        }
    }

    // Original CheckForConflict function, was producing double & triple collectibles in same space
    // void CheckForConflict()
    // {
    //     // Get each obstacle currently in game:
    //     foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
    //     {
    //         // If obstacle not at spawn location and game not over, spawn collectible:
    //         if (!(gameObject.transform.position.x == obstacle.transform.position.x) && gameManager.gameOver == false)
    //         {
    //             SpawnObject(transform.position);
    //         } 
    //         else
    //         {
    //             // This spawn position allows some randomness for distance between spawned collectibles:
    //             Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(0.0f, 0.005f), transform.position.y);

    //             SpawnObject(spawnPosition);
    //         }
    //     }
    // }

    void SpawnObject(Vector2 spawnPosition)
    {
        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Object.Instantiate.html
        Instantiate(gameObjectToSpawn, spawnPosition, Quaternion.identity);
        spawnCooldownTimer = RandomizeSpawnTimer(spawnCooldownMin, spawnCooldownMax);
    }
}