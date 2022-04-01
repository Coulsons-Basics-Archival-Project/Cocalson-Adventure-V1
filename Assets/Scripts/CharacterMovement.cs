using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public bool allowMovement = true;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouch = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        if (allowMovement)
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            
        jump = false;
    }
}
