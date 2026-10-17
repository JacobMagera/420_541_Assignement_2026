using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))] // Ensures that a Rigidbody component is attached to the GameObject
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnspeed = 150f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Ground Check Settings")]
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float turnInput;
    private bool isGrounded;
    private bool jumpRequested = false;

    public bool IsGrounded => isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position + transform.up * groundDistance / 2, -transform.up, groundDistance, groundMask);

        turnInput = Input.GetAxisRaw("Horizontal");

        float moveZ = Input.GetAxisRaw("Vertical");

        transform.Rotate(0f, turnInput * turnspeed * Time.deltaTime, 0f);

        moveDirection = transform.forward * moveZ;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();

        if (jumpRequested)
        {
            Jump();

            jumpRequested = false;
        }
    }

    private void MovePlayer()
    {
        Vector3 targetVelocity = moveDirection * moveSpeed;

        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}