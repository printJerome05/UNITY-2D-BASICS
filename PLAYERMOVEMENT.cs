using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVEMENT : MonoBehaviour
{
    // for groundchecking and dont double jump
    private bool grounded;

    private Rigidbody2D rb;
    private Animator anim;

    //for walking and jumping
    private float dirX;
    [SerializeField] private float walkSpeed = 7f;
	[SerializeField] private float jumpSpeed = 14f;

    // can be converted into into 0 first 
    // defined in the animator as a int 
    // parameter is int type
    private enum MovementState {idle, walking, jumping, falling}
    private MovementState state = MovementState.idle;


    //for ground check so that our character will not fly if we spam the jump
    [SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;



	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
		

		// walk left and right 
		dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * walkSpeed, rb.velocity.y);



        //  jump for overall in unity input manager use GetButtonDown
        // then state the name of the input
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
			
			Debug.Log("Is Jumping");

			// can do below code just define parameters in the unity editor first
			//anim.SetBool("isJumping", true);

		}
    
        UpdateAmimation();

      

    }

    private void UpdateAmimation()
    {
        MovementState state;

		if (dirX > 0f)
		{
			state = MovementState.walking;
		}
		else if (dirX < 0f)
		{
            // can do code below if simple games
            // anim.SetBool("isWalking", true);
            state = MovementState.walking;

		}
		else
		{
			state = MovementState.idle;
			
		}

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
			state = MovementState.falling;
		}

        anim.SetInteger("state", (int)state);
	}

    //for ground check boolean
    // need to define a ground in layers to define what is ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
