using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerObject;
    [SerializeField] Vector3 cameraOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // https://discussions.unity.com/t/how-to-get-camera-to-follow-player-2d/128194
    void Update()
    {
        if (playerObject != null)
        {
            transform.position = new Vector3(playerObject.position.x, 0, -10) + cameraOffset;
        }
    }
}
