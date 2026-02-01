using UnityEngine;

public class SpawnWorldObstacles : MonoBehaviour
{
    // [SerializeField] private GameManager gameManager;
    [SerializeField] GameObject gameObjectToSpawn;
    private float spawnCooldownTimer = 0;
    [SerializeField] float spawnCooldownMin;
    [SerializeField] float spawnCooldownMax;

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
    }

    float RandomizeSpawnTimer(float min, float max)
    {
        return Random.Range(min, max);
    }

    void SpawnObject()
    {
        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Object.Instantiate.html
        Instantiate(gameObjectToSpawn, transform.position, Quaternion.identity); 
        spawnCooldownTimer = RandomizeSpawnTimer(spawnCooldownMin, spawnCooldownMax);
    }
}
