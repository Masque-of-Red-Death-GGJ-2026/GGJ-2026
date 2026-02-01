using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioSource gameMusic;
    
    [SerializeField] AudioClip gameWin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playWin()
    {
        Debug.Log("Game Win");
        gameMusic.Pause();
        gameMusic.loop = false;
        gameMusic.clip = gameWin;
        gameMusic.Play();
    }

    public void playGameOver()
    {
        gameMusic.Pause();
        gameMusic.loop = false;
        gameMusic.clip = gameOver;
        gameMusic.Play();
    }
}
