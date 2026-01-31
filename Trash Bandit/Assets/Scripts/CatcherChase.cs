using UnityEngine;

public class CatcherChase : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    

    void FixedUpdate()
    {
        // Moves rigidbody to the right at a speed of moveSpeed
        rb.linearVelocity = Vector2.right * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GameOver");
        }
    }
}