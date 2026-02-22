using UnityEngine;

public class MoveHouse : MonoBehaviour
{
    public float speed = 5f;
    public float parallaxFactor = 0.7f;

    [HideInInspector] public HouseSpawner spawner;

    private int DestroyHouseXPos = -60;

    void Uodate()
    {
        transform.position += new Vector3(-1, 0) * speed * parallaxFactor * Time.deltaTime;

        //house off screen?
        if (transform.position.x <= DestroyHouseXPos)
        {
            spawner.numOfHouses--;
            Destroy(gameObject);
        }
    }
}