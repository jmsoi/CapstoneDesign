using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2f;
    public float sideSpeed = 2f;
    bool isGround = true;
    float timer = 0f;

    void Start() => rb = GetComponent<Rigidbody>();
    void Update() {
        if (GameManager.Instance.isGameStarted) {
            Vector3 targetVelocity = new Vector3(0, 0, 1).normalized * speed;
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, targetVelocity.z);
            if(Pointer.current.press.ReadValue() == 1) MoveBall();
        }

        if(!isGround) {
            timer += Time.deltaTime;
            if(timer > 1.5f) GameManager.Instance.GameOver();
        } else timer = 0f;
    }

    void OnCollisionEnter(Collision collision) {
        isGround = true;
        if(collision.gameObject.tag == "Goal") GameManager.Instance.Win();
    }
    void OnCollisionExit(Collision collision) => isGround = false;

    public void MoveBall(){
        float directionX = (Pointer.current.position.ReadValue().x / Screen.width > 0.5f) ? 1f : -1f;
        rb.AddForce(new Vector3(directionX * sideSpeed, 0, 0));
    }

}
