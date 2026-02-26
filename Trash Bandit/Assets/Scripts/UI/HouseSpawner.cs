using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject[] housePrefabs;

    //spawn settings
    public int numOfHouses = 1;
    public float spawnX = 20f;

    void Start()
    {
        SpawnHouseAt(Camera.main.transform.position.x + 8f);
        SpawnHouseAt(Camera.main.transform.position.x + 16f);
        SpawnHouseAt(Camera.main.transform.position.x + 24f);
        numOfHouses = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfHouses <= 2)
        {
            SpawnHouse();
            numOfHouses++;
        }
    }

    private void SpawnHouseAt(float xPos)
    {
        int randomIndex = Random.Range(0, housePrefabs.Length);
        GameObject newHouse = Instantiate(
            housePrefabs[randomIndex],
            new Vector3(xPos, transform.position.y, 0f),
            Quaternion.identity
        );

        newHouse.GetComponent<MoveHouse>().spawner = this;
    }

    private void SpawnHouse()
    {
        SpawnHouseAt(Camera.main.transform.position.x + spawnX);
    }

}
