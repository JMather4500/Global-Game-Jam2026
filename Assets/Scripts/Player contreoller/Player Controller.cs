using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;



public class PlayerController : MonoBehaviour
{
    private float moveDirection;
    [SerializeField] public float moveSpeed;
    [SerializeField] private float jump;
    private bool faceRight = true;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    

     void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && Grounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }

        if(Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
    }

    float getMoveSpeed()
    {
        return moveSpeed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
    }

    private bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);


    }

    private void Flip()
    {
        if (faceRight && moveDirection < 0f || !faceRight && moveDirection > 0f)
        {
            faceRight = !faceRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
