using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameOverScreenScript gameOverScreen;
    public int numberOfObstacles = 0;
    public bool moveWorld = true;
    private bool gameOver = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement.OnCatch += On_Catch;
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

    // Update is called once per frame
    void Update()
    {
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
