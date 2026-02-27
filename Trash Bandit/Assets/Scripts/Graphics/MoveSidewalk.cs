using UnityEngine;

public class MoveSidewalk : MonoBehaviour
{
    [SerializeField] MoveWorldBackground moveWorldBackgroundController;
    [SerializeField] int destroySidewalkXPos = -60;
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

    void Start()
    {
        moveWorldBackgroundController = FindObjectOfType<MoveWorldBackground>();
    }

    // Update is called once per frame
    void Update()
    {
        float gameDifficultySpeed = CheckGameState();
        float step = 1.0f * Time.deltaTime;
        gameObject.transform.position += new Vector3(-1, 0) * speed * gameDifficultySpeed * Time.deltaTime;

        // If object out of view, destroy:
        if (gameObject.transform.position.x <= destroySidewalkXPos)
        {
            Destroy(gameObject);
            moveWorldBackgroundController.numOfSidewalks--;
        }
    }
}
