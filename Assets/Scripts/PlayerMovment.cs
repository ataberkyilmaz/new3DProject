using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -15f;

    public Transform groundCheck;
    public LayerMask groundMask;
    private float groundDistance = 0.4f;
    
    
    private Vector3 velocity;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        Move();
        Jump();
        Spirit();
        
        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Spirit() {
        speed = Input.GetKey(KeyCode.LeftShift) ? 20f : 12f;
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}