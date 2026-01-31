using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] GameObject gameObjectToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     SpawnObject();
        // }
    }

    void SpawnObject()
    {
        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Object.Instantiate.html
        Instantiate(gameObjectToSpawn, new Vector2(10.5f, 0.545f), Quaternion.identity);
    }
}
