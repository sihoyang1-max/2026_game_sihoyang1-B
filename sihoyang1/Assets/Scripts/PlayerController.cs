using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rd;
    private bool isGrounded;
    private float moveInput;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rd.linearVelocity = new Vector2(moveInput * moveSpeed, rd.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rd.linearVelocity = new Vector2(rd.linearVelocity.x, 0f);
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}   // Start is called once before the first execution of Update after the MonoBehaviour is created

