using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 12f;
    public float jumpForce = 2f;
    public float gravity = -9.81f;
    public float sensitivity = 100f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;
    private float yRotation = 0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Look();
        Animate();
        Attacks();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }
    }

    void Move()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        bool corriendo = Keyboard.current.leftShiftKey.isPressed;

        float velocidadActual;

        if (corriendo)
        {
            velocidadActual = 60f;
        }
        else
        {
            velocidadActual = speed;
        }

        controller.Move(move * velocidadActual * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = lookInput.x * sensitivity * Time.deltaTime;

        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    void Animate()
    {
        if (animator == null)
        {
            return;
        }

        animator.SetFloat("VelX", moveInput.x);
        animator.SetFloat("VelY", moveInput.y);
    }

    void Attacks()
    {
        if (animator == null)
        {
            return;
        }

        // PATADA CON Q
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Patada");
        }

        // GOLPE CON E
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Golpe");
        }
    }
}