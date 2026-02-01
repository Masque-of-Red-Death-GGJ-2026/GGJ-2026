using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScreenScript : MonoBehaviour
{
    [SerializeField] GameObject GameWinScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        GameWinScreen.SetActive(false);
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