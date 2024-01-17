using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed;
    public float sprintSpeed;
    public float gravity;
    public float jumpHeight;

    [HideInInspector] public bool canMove;

    bool isSprinting;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [HideInInspector] public bool isGrounded;

    Vector3 move;
    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        move = Vector3.Normalize(transform.right * x + transform.forward * z);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (canMove)
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            controller.Move(move * CurrentStateSpeed() * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
        }
        else
        {
            isSprinting = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    float CurrentStateSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && move != Vector3.zero)
        {
            isSprinting = true;
            return sprintSpeed;
        }
        else
        {
            isSprinting = false;
            return walkSpeed;
        }
    }
}
