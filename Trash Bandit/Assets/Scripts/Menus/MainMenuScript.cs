using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void DisplayControls()
    {
        SceneManager.LoadScene("ControlsScene");
    }

    public void DisplayCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

}
