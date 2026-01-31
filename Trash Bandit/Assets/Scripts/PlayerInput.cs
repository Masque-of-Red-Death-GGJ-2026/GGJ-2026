using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput { get; private set; }
    public bool jumpInput { get; private set; }
    
    public event EventHandler OnJumpInputPressed;
    
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            horizontalInput = -1;
        } else if (Keyboard.current.dKey.isPressed)
        {
            horizontalInput = +1;
        }
        else
        {
            horizontalInput = 0;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            OnJumpInputPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
