using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroMovement : MonoBehaviour
{
    public float jumpForce;

    //check radio
    public Transform Checker;
    public float radioChecker;

    //check if it is floor
    public bool isGrounded;
    public LayerMask isItFloor;

    //this is knockback
    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool knockFromRight;


    [HideInInspector]
    public Rigidbody2D rb;
    
    [HideInInspector]
    public Animator Animator;
    public float horizontal;
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
        if(KBcounter <= 0) 
        {
            rb.velocity = new Vector2(horizontal, rb.velocity.y);
        }
        else
        {
            if (knockFromRight) rb.velocity = new Vector2(-KBforce, KBforce);
            if (knockFromRight == false) rb.velocity = new Vector2(KBforce, KBforce);

            KBcounter -= Time.deltaTime;
        }
    }


   
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }


  
        
 
}

