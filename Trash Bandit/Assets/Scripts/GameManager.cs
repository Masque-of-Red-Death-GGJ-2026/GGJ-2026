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
    public int currentScore = 0;
    public int numberOfObstacles = 0;
    public bool moveWorld = true;
    private bool gameOver = false;
    public TextMeshProUGUI GameScoreTextUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        catcherChase.OnCatch += On_Catch;
    }

    private void On_Catch(object sender, EventArgs e)
    {
        gameOver = true;
        gameOverScreen.ShowGameOver();
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
            GameWinScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if game is won each frame:
        CheckWinCondition();

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
