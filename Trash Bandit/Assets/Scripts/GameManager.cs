using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
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
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        catcherChase.OnCatch += On_Catch;
        
        // Hide cursor while playing game:
        Cursor.visible = false;
    }

    private void On_Catch(object sender, EventArgs e)
    {
        gameOver = true;
        GameOver();
        gameOverScreen.ShowGameOver();
        musicManager.playGameOver();
    }

    private void On_Obstacle_Collision(object sender, EventArgs e)
    {
        moveWorld = false;
    }

    private void CheckWinCondition()
    {
        if (currentScore >= winningScore)
        {
            // Update UI:
            moveWorld = false;
            gameOver = true;
            GameOver();
            GameWinScreen.SetActive(true);
            musicManager.playWin();
        }
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

    // Update is called once per frame
    void Update()
    {
        // Check if game is won each frame:
        if (!gameOver)
        {
            CheckWinCondition();
        }

        if (playerMovement.CheckCollision())
        {
            moveWorld = false;
        }
        else
        {
            moveWorld = true;
        }
    }
}