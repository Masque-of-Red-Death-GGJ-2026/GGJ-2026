using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public bool jumpInput { get; private set; }
    
    public event EventHandler OnJumpInputPressed;
    public event EventHandler OnChitterInputPressed;
    
    // Update is called once per frame
    void Update()
    {
        // Fire jump event on spacebar press
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            OnJumpInputPressed?.Invoke(this, EventArgs.Empty);
        }

        // Chitter input
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            OnChitterInputPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
