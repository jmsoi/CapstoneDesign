using UnityEngine;

public class MainCam : MonoBehaviour
{
    public Transform ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(ball.position.x, ball.position.y + 5 - 2.5f, ball.position.z - 10 + 2.5f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ball != null)
        {
            transform.position = new Vector3(ball.position.x, ball.position.y + 5 - 2.5f, ball.position.z - 10 + 2.5f);
        }
    }
}
