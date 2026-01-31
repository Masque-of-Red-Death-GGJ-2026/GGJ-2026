using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput { get; private set; }
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
    }
}
