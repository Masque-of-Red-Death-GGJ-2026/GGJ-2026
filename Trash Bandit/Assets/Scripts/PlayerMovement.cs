using Unity.Mathematics.Geometry;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float playerAcceleration;
    [SerializeField] float playerMaxVelocity;

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(playerInput.horizontalInput, 0) * playerAcceleration, ForceMode2D.Force);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, playerMaxVelocity);
    }

    }
