using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] float jumpForce; // How high the raccoon jumps
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip[] eatSounds;

    private float jumpSkipFramesTimer;
    private bool jumpReadyToCheckGround;

    public EventHandler OnObstacleCollision;

    void Start()
    {
        // Set up listener for jump input
        playerInput.OnJumpInputPressed += On_Jump_Input_Pressed;
    }

    private void On_Jump_Input_Pressed(object sender, EventArgs e)
    {
        if (CheckGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);

            // Reset variable related jump "buffer" for the raccoons animation
            jumpReadyToCheckGround = false;
            jumpSkipFramesTimer = 0.3f;
        }
    }

    private void Update()
    {
        // Timer for a "buffer" on the jump animation switching back to walking animation
        // So raccoon doesn't switch to walking immediately after jumping
        if (jumpSkipFramesTimer > 0)
        {
            jumpSkipFramesTimer -= Time.deltaTime;
        }
        else
        {
            jumpReadyToCheckGround = true;
        }

        // If on ground and buffer since jump has passed
        if (CheckGrounded() && jumpReadyToCheckGround)
        {
            animator.SetBool("Jumping", false);
        }
    }

    bool CheckGrounded()
    {
        // Get bottom center of player's collider
        Vector2 bottomCenter = new Vector2(
            playerCollider.bounds.center.x,
            playerCollider.bounds.center.y - playerCollider.bounds.extents.y
        );
        
        // Boxcast at players feet, if cast hits object on "platform" layer, returns true
        var boxHeight = 0.5f;
        var raycast = Physics2D.BoxCast(bottomCenter, new Vector2(playerCollider.bounds.size.x, boxHeight), 0, Vector2.down, 0f, LayerMask.GetMask("Platform"));
        return raycast.collider;
    }

    public bool CheckCollision()
    {
        Vector3 rightCenter = new Vector3(
            playerCollider.bounds.center.x + playerCollider.bounds.extents.x,
            playerCollider.bounds.center.y
        );
        var boxHeight = 0.5f;
        var collisioncast = Physics2D.BoxCast(rightCenter, new Vector2(boxHeight ,playerCollider.bounds.size.y), 0, Vector2.right, 0f);
        return collisioncast.collider;
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Chaser"))
    //     {
    //         OnCatch?.Invoke(this, EventArgs.Empty);
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        // If user is colliding with collectible
        if (col.CompareTag("Collectible"))
        {
            // Play collection sound
            audioSource.clip = eatSounds[Random.Range(0, eatSounds.Length)];
            audioSource.Play();
        }
    }
}
