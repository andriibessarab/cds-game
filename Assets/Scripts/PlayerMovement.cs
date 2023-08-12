using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 20f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;
    
    void Update()
    {
        // Get input from player
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        // Check for jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
        // Check for crouch
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}
