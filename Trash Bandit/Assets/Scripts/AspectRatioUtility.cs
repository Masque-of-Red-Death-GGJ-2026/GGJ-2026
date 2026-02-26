using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AspectRatioUtility : MonoBehaviour
{
    // Credit to: https://www.youtube.com/watch?v=PClWqhfQlpU
    private float savedAspectRatio;
    void Start()
    {
        AdjustAspectRatio();
    }

    void Update()
    {
        if (savedAspectRatio != (float)Screen.width / (float)Screen.height)
        {
            AdjustAspectRatio();
        }
    }

    void AdjustAspectRatio()
    {
        float targetAspectRatio = 16.0f/9.0f;
        float screenAspectRatio = (float)Screen.width / (float)Screen.height;
        savedAspectRatio = screenAspectRatio;
        float scaleHeight = screenAspectRatio / targetAspectRatio;

        Camera gameCam = GetComponent<Camera>();

        Rect rect = gameCam.rect;

        if (scaleHeight < 1)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        gameCam.rect = rect;
    }
}
