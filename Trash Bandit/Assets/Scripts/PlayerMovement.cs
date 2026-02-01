using System;
using Unity.Mathematics.Geometry;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Collider2D collider;
    [SerializeField] float groundAcceleration;
    [SerializeField] float playerMaxVelocity;
    [SerializeField] float jumpForce;
    [SerializeField] private float airAcceleration;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip[] eatSounds;

    private float jumpSkipFramesTimer;
    private bool jumpReadyToCheckGround;

    public EventHandler OnObstacleCollision;

    // Update is called once per frame
    void Start()
    {
        playerInput.OnJumpInputPressed += On_Jump_Input_Pressed;
    }

    private void On_Jump_Input_Pressed(object sender, EventArgs e)
    {
        if (CheckGrounded())
        {
            rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            jumpReadyToCheckGround = false;
            jumpSkipFramesTimer = 0.3f;
        }
    }

    private void Update()
    {
        if (jumpSkipFramesTimer > 0)
        {
            jumpSkipFramesTimer -= Time.deltaTime;
        }
        else
        {
            jumpReadyToCheckGround = true;
        }
        if (CheckGrounded() && jumpReadyToCheckGround)
        {
            animator.SetBool("Jumping", false);
        }
        // if (CheckGrounded())
        // {
        //     animator.SetBool("Jumping", false);
        // }
    }

    bool CheckGrounded()
    {
        Vector2 bottomCenter = new Vector2(
            collider.bounds.center.x,
            collider.bounds.center.y - collider.bounds.extents.y
        );
        
        var boxHeight = 0.5f;
        var raycast = Physics2D.BoxCast(bottomCenter, new Vector2(collider.bounds.size.x, boxHeight), 0, Vector2.down, 0f, LayerMask.GetMask("Platform"));
        return raycast.collider;
        //var raycast = Physics2D.Raycast(bottomCenter, Vector2.down, 0.5f, LayerMask.GetMask("Platform"));
    }

    public bool CheckCollision()
    {
        Vector3 rightCenter = new Vector3(
            collider.bounds.center.x + collider.bounds.extents.x,
            collider.bounds.center.y
        );
        var boxHeight = 0.5f;
        var collisioncast = Physics2D.BoxCast(rightCenter, new Vector2(boxHeight ,collider.bounds.size.y), 0, Vector2.right, 0f);
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
        if (col.CompareTag("Collectible"))
        {
            // Add points via GameManager:
            audioSource.clip = eatSounds[Random.Range(0, eatSounds.Length)];
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        
    }
}
