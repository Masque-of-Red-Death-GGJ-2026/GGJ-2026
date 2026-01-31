using UnityEngine;

public class CatcherChase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

[SerializeField] Transform player;
[SerializeField] Rigidbody2D playerRb;
[SerializeField] float startGap = 8f;
[SerializeField] float maxGap = 10f;
[SerializeField] float catchGap = 1f;
[SerializeField] float gainWhenStopped = 3f; //catcher gains if player stops/slows
[SerializeField] float loseWhenMoving = 1.5f; //catcher falls back when player moves
[SerializeField] float minMoveSpeed = 0.5f; //what counts as "moving"
private float gap;
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

        //move catcher behind player
        transform.position = new Vector3(
            player.position.x - gap,
            transform.position.y,
            transform.position.z
        );

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
        Debug.Log("Caught!");
        // TODO: trigger game over/ disable player movement
    }

    //optional help to read gap
    public float GetGap() => gap;
}
