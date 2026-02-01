using NUnit.Framework.Constraints;
using UnityEngine;

public class GameOverScreenScript : MonoBehaviour
{
    public GameObject GameOverScreen;

    //When game starts game over screen is not visable
    private void Awake()
    {
        GameOverScreen.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameOverScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
