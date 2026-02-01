using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;

    //When game starts game over screen is not visable
    private void Awake()
    {
        GameOverScreen.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameOverScreen.SetActive(true);
    }

    // Function called on main menu button click:
    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    // Function called on restart button click:
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}