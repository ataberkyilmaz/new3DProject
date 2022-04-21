using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -15f;

    public Transform groundCheck;
    public LayerMask groundMask;
    private float groundDistance = 0.4f;

    private bool isMoving;
    private bool isRunning;
    
    
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
        if (speed > 13 && isMoving) {
            animator.SetBool("isRunning",true);
        }
        else {
            animator.SetBool("isRunning",false);
        }
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("isJumping",true);
        }
        animator.SetBool("isJumping",false);
    }

    private void Move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        //anim
        isMoving = x != 0 || z != 0;
        animator.SetBool("isWalking",isMoving);

    }
}