using UnityEngine;

public class MoveHouse : MonoBehaviour
{
    public float moveSpeed = 5f;

    [Range(0f, 1f)]
    public float parallaxFactor = 0.7f;

    [HideInInspector] public HouseSpawner spawner;

    void Uodate()
    {
        transform.position += Vector3.left * moveSpeed * parallaxFactor * Time.deltaTime;

        //house off screen?
        if (transform.position.x < Camera.main.transform.position.x - 15f)
        {
            spawner.numOfHouses--;
            Destroy(gameObject);
        }
    }
}