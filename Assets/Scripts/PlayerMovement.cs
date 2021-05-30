using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float acceleration;
    public float maxSpeed;
    public float linearDrag;
    public float jumpForce;
    public float airLinearDrag;
    public float groundRaycastLenght;
    public LayerMask groundLayer;

    [Header("Inheritance")]
    public GameObject groundChack;
    public Rigidbody rb;

    [Header("Parameters")]
    public bool isGrounded;
    public bool changingDirection => (rb.velocity.x > 0f && inputAxis.x < 0f) || (rb.velocity.x < 0f && inputAxis.x > 0f);

    private Vector2 inputAxis;

    private Vector2 getInput()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRaycastLenght, groundLayer);
        Debug.Log(isGrounded);
        inputAxis = getInput();
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(inputAxis.x,0,0) * acceleration);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y, rb.velocity.z);
        }

        if (!isGrounded)
        {
            rb.drag = airLinearDrag;
        }
        else if (Mathf.Abs(inputAxis.x) < 0.4f || changingDirection)
        {
            rb.drag = linearDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastLenght);
    }
}
