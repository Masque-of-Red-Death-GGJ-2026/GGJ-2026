using System;
using UnityEngine;

public class DestroyObstacleOutOfView : MonoBehaviour
{
    [SerializeField] Vector2 moveObstacleVector = new Vector2(5.0f, 0.0f);
    [SerializeField] Vector2 target = new Vector2(-11.0f, 0.0f);
    private float speed = 5;
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

    // Update is called once per frame
    void Update()
    {
        float gameDifficultySpeed = CheckGameState();
        // Move towards player:
        float step = 1.0f * Time.deltaTime;
        transform.position += new Vector3(-1, 0) * speed * gameDifficultySpeed * Time.deltaTime;

        // If object out of view, destroy:
        if (gameObject.transform.position.x <= -11)
        {
            Destroy(gameObject);

            // Tell game manager number reduced:
            GameManager.Instance.numberOfObstacles--;
        }
    }
}
