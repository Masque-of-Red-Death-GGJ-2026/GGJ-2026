using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource gameOver;
    [SerializeField] AudioSource gameMusic;
    [SerializeField] AudioSource gameWin;
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
        gameMusic.Pause();
        gameWin.Play();
    }

    public void playGameOver()
    {
        gameMusic.Pause();
        gameOver.Play();
    }
}
