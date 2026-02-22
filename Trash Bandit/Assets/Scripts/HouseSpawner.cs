using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject[] housePrefabs;

    //spawn settings
    public int numOfHouses = 1;
    public float spawnX = 20f;
    public float spawnY = -0.6f;

    void Start()
    {
        SpawnHouse();
        numOfHouses++;
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfHouses <= 1)
        {
            SpawnHouse();
            numOfHouses++;
        }
    }

    private void SpawnHouse()
    {
        int randomIndex = Random.Range(0, housePrefabs.Length);
        GameObject newHouse = Instantiate(
            housePrefabs[randomIndex],
            new Vector3(Camera.main.transform.position.x +spawnX, spawnY, 2f),
            Quaternion.identity
        );

        newHouse.GetComponent<MoveHouse>().spawner = this;
    }

}
