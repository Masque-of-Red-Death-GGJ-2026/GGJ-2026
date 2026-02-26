using UnityEngine;

public class MoveWorldBackground : MonoBehaviour
{
    [SerializeField] GameObject sidewalk;
    public int numOfSidewalks = 1;
    
    void Start()
    {
        // Spawn additional sidewalk at start:
        SpawnSidewalk();
        numOfSidewalks++;
    }

    void Update()
    {
        // Check number of sidewalks to determine if sidewalk should be spawned:
        if (numOfSidewalks <= 1)
        {
            SpawnSidewalk();
            numOfSidewalks++;
        }
    }

    // Spawn new sidewalk:
    private void SpawnSidewalk()
    {
        Instantiate(sidewalk, transform.position, Quaternion.identity);
    }
}