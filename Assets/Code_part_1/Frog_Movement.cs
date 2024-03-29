﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;
    private bool isGrounded = false;
    private Collider2D cl;

    public LayerMask groundLayer;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public float jumpDelayTime = 1f;
    public bool moving = false;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        an = transform.GetComponent<Animator>();
        cl = transform.GetComponent<Collider2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(cl, groundLayer);

        if (moving && isGrounded)
        {
            Invoke("Jump", jumpDelayTime);
        }
    }
    private void FixedUpdate()
    {
        an.SetFloat("yVelocity", rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(moveSpeed, jumpForce);
            an.SetBool("isJumping", true);
        }
    }
}
