using UnityEngine;

public class MoveHouse : MonoBehaviour
{
    public float speed = 5f;
    public float parallaxFactor = 0.7f;

    [HideInInspector] public HouseSpawner spawner;

    private int DestroyHouseXPos = -15;

    private float CheckGameState()
    {
        switch(GameManager.Instance.gameState)
        {
            case GameManager.GameState.GameLost:
                return 0;
            case GameManager.GameState.Level0:
                return 1;
            case GameManager.GameState.Level1:
                return 1.5f;
            case GameManager.GameState.Level2:
                return 2;
            case GameManager.GameState.Level3:
                return 2.5f;
            case GameManager.GameState.GameWon:
                return 0;
            default:
                return 1;
        }
    }

    void Update()
    {
        float gameDifficultySpeed = CheckGameState();
        transform.position += new Vector3(-1, 0) * speed * gameDifficultySpeed * parallaxFactor * Time.deltaTime;

        //house off screen?
        if (transform.position.x <= DestroyHouseXPos)
        {
            spawner.numOfHouses--;
            Destroy(gameObject);
        }
    }
}