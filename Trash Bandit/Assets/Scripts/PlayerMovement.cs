using System;
using Unity.Mathematics.Geometry;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Collider2D collider;
    [SerializeField] float groundAcceleration;
    [SerializeField] float playerMaxVelocity;
    [SerializeField] float jumpForce;
    [SerializeField] private float airAcceleration;

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
        }
    }

    private void Update()
    {
        
    }

    bool CheckGrounded()
    {
        Vector3 bottomCenter = new Vector3(
            collider.bounds.center.x,
            collider.bounds.center.y - collider.bounds.extents.y,
            collider.bounds.center.z
        );
        var boxHeight = 1f;
        var raycast = Physics2D.BoxCast(bottomCenter, new Vector2(collider.bounds.size.y, boxHeight), 0, Vector2.down, 0f, LayerMask.GetMask("Platform"));
        return raycast.collider != null;
        
        //var raycast = Physics2D.Raycast(bottomCenter, Vector2.down, 0.5f, LayerMask.GetMask("Platform"));
    }

    void FixedUpdate()
    {
        var acceleration = CheckGrounded() ? groundAcceleration : airAcceleration;
        rb.AddForce(new Vector2(playerInput.horizontalInput, 0) * acceleration, ForceMode2D.Force);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, playerMaxVelocity);
    }
}
