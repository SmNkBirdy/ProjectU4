using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravity;
    public bool isGrounded;
    public CharacterController controller;
    private Vector3 inputAxis;
    public float jumpSpeed;
    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        inputAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if (inputAxis.magnitude >= 0.1)
        {
            controller.Move(inputAxis * speed * Time.deltaTime);
        }

        if (jumpSpeed > 0)
        {
            jumpSpeed -= 9.8f * Time.deltaTime;
        }
        else if (jumpSpeed < 0)
        {
            jumpSpeed = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpSpeed = isGrounded ? jumpForce + gravity : jumpSpeed;
        }
        if (jumpSpeed > 0 || !isGrounded)
        {
            controller.Move(new Vector3(0, jumpSpeed + (isGrounded ? 0.0f : -1.0f) * gravity, 0) * Time.deltaTime);
        }
    }
}
