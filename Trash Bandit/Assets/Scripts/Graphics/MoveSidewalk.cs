using UnityEngine;

public class MoveSidewalk : MonoBehaviour
{
    [SerializeField] MoveWorldBackground moveWorldBackgroundController;
    [SerializeField] int destroySidewalkXPos = -60;
    private float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveWorldBackgroundController = FindObjectOfType<MoveWorldBackground>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = 1.0f * Time.deltaTime;
        gameObject.transform.position += new Vector3(-1, 0) * speed * Time.deltaTime;

        // If object out of view, destroy:
        if (gameObject.transform.position.x <= destroySidewalkXPos)
        {
            Destroy(gameObject);
            moveWorldBackgroundController.numOfSidewalks--;
        }
    }
}
