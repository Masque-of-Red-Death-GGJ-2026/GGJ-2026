using UnityEngine;

public class CatcherChase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

[Header("References")]
public Transform player;
public Rigidbody2D playerRb;

[Header("Gap Settings")]
public float startGap = 8f;
public float maxGap = 10f;
public float catchGap = 1f;

[Header("Chaser Tuning")]
public float gainWhenStopped = 3f; //catcher gains if player stops/slows
public float loseWhenMoving = 1.5f; //catcher falls back when player moves
public float minMoveSpeed = 0.5f; //what counts as "moving"

float gap;
public bool IsCaught { get; private set; }
    void Start()
    {
        gap = startGap;
        IsCaught = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player || IsCaught) return;

        float speed = playerRb.linearVelocity.magnitude;

        //player stopped or slow
        if (speed < minMoveSpeed)
        {
            gap -= gainWhenStopped * Time.deltaTime;
        }
        else
        {
            gap += loseWhenMoving * Time.deltaTime;
        }

        gap = Mathf.Clamp(gap, catchGap, maxGap);

        // Did we get caught?
        if (gap <= catchGap + 0.0001f)
        {
            IsCaught = true;
            OnCaught();
        }
    }
    private void OnCaught()
    {
        //what happens when caught
    }

    //optional help to read gap
    public float GetGap() => gap;
}
