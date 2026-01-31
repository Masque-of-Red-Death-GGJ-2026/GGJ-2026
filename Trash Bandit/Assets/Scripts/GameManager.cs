using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    public bool moveWorld = true;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
