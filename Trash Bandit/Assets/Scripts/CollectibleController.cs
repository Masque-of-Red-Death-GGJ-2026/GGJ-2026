using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Add points via GameManager:
            gameManager.currentScore++;
            gameManager.GameScoreTextUI.text = gameManager.currentScore.ToString();
        }
    }
}
