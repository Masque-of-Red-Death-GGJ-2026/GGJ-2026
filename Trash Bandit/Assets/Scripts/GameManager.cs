using System;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance{get; private set;}
    public enum GameState
    {
        GameLost,
        Level0,
        Level1,
        Level2,
        Level3,
        GameWon
    }
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CatcherChase catcherChase;
    [SerializeField] GameOverScreenScript gameOverScreen;
    [SerializeField] GameObject GameWinScreen;
    [SerializeField] int winningScore = 10;
    [SerializeField] GameObject player;
    [SerializeField] MusicManager musicManager;
    public int currentScore = 0;
    public int numberOfObstacles = 0;
    public bool moveWorld = true;
    public bool gameOver = false;
    public TextMeshProUGUI GameScoreTextUI;
    [SerializeField] GameObject gameOverGraphic;
    public GameState gameState {get; private set;} = GameState.Level0;

    public event EventHandler OnGameStateChanged;

    void Awake()
    {
        Instance  = this;
    }
    void Start()
    {
        // Listener for raccoon caught event (for game over)
        catcherChase.OnCatch += On_Catch;
        
        // Hide cursor while playing game:
        Cursor.visible = false;
    }

    void Update()
    {
        switch(gameState)
        {
            case GameState.GameLost:
                gameOver = true;
                GameOver();
                gameOverScreen.ShowGameOver();
                musicManager.playGameOver();
                gameOverGraphic.SetActive(true);
                break;
            case GameState.Level0:
                if (currentScore >= 3)
                {
                    ChangeGameState(GameState.Level1);
                }
                break;
            case GameState.Level1:
                if (currentScore > 5)
                {
                    ChangeGameState(GameState.Level2);
                }
                break;
            case GameState.Level2:
                if (currentScore > 7)
                {
                    ChangeGameState(GameState.Level3);
                }
                break;
            case GameState.Level3:
                if (currentScore >= 10)
                {
                    OnGameStateChanged?.Invoke(this, EventArgs.Empty);
                    moveWorld = false;
                    gameOver = true;
                    GameOver();
                    GameWinScreen.SetActive(true);
                    musicManager.playWin();
                    ChangeGameState(GameState.GameWon);
                }
                break;
            case GameState.GameWon:
                break;
        }
    }

    private void On_Catch(object sender, EventArgs e)
    {
        ChangeGameState(GameState.GameLost);
    }

    private void ChangeGameState(GameState gameState)
    {
        OnGameStateChanged?.Invoke(this, EventArgs.Empty);
        this.gameState = gameState;
    }

    private void GameOver()
    {
        // Once game over, destroy all obstacles:
        foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(obstacle);
        }

        // Once game over, destroy all collectibles:
        foreach (GameObject collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            Destroy(collectible);
        }

        // Disable player rb to prevent movement:
        player.GetComponent<Rigidbody2D>().simulated = false;

        // Display cursor:
        Cursor.visible = true;
    }
}