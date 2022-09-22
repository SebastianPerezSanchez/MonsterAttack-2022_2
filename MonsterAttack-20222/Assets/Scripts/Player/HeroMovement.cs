using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform Checker;
    public float radioChecker;
    public bool isGrounded;
    public LayerMask isItFloor;

    private Rigidbody2D rb;
    private Animator Animator;
    private float horizontal;
    private bool doubleJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f, 1.0f);
        else if (horizontal >0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);

        Animator.SetBool("Running", horizontal != 0.0f);

        
        if( Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Animator.SetTrigger("takeOff");
            Jump();
        }

        if( Input.GetKeyDown(KeyCode.W) && isGrounded == false && doubleJump == false)
        {
            Animator.SetTrigger("takeOff");
            doubleJump = true;
            Jump();
        }

        if(isGrounded){
            doubleJump = false;
            Animator.SetBool("isJumping", false);
        } else {
            Animator.SetBool("isJumping", true);
        }

        isGrounded = Physics2D.OverlapCircle(Checker.position, radioChecker, isItFloor);

        
       
       

    }



   private void FixedUpdate()
    {
       
            rb.velocity = new Vector2(horizontal, rb.velocity.y);
        
    }

   
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
        
 
}

