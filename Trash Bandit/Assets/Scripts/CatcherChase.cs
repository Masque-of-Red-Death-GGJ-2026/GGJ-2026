using System;
using UnityEngine;

public class CatcherChase : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    public EventHandler OnCatch;
    

    void FixedUpdate()
    {
        // Moves rigidbody to the right at a speed of moveSpeed
        //rb.linearVelocity = Vector2.right * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            OnCatch?.Invoke(this, EventArgs.Empty);
        }
    }
}