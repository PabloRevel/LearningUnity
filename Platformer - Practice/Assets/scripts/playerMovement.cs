using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    
    public Rigidbody2D body;
    public BoxCollider2D bottomCollider;
    public LayerMask groundMask;
    public float speed = 5f;
    public float jump_speed = 10f;
    public bool is_grounded = false;
    public Animator animator;
    float xInput;
    float yInput;
    bool jumpInput;

    void Update() // 1 x Frame
    {
        getInput();
    }
    private void FixedUpdate() // Independent of Frames generation
    {
        checkGround();
        moveWithInput();
        animator.SetFloat("xVelocity", Math.Abs(body.linearVelocityX));
        animator.SetFloat("yVelocity", body.linearVelocityY);
    }

    void getInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetButtonDown("Jump");
        Debug.Log("xInput: " + xInput.ToString());
        Debug.Log("yInput: " + yInput.ToString());
        Debug.Log("jumpInput: " + jumpInput.ToString());

    }
    void moveWithInput(){
        if(Math.Abs(xInput)>0)
        {
            body.linearVelocity = new Vector2(xInput*speed, body.linearVelocityY);
            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction * 2, 2, 1 );
        }
        if(jumpInput && is_grounded)
        {
            Debug.Log("Jumping");
            body.linearVelocity = Vector2.up * jump_speed;
            is_grounded = false;
            animator.SetBool("isJumping", !is_grounded);
        }
    }
    void checkGround(){
        bool origin_grounded = is_grounded;
        is_grounded = Physics2D.OverlapAreaAll(bottomCollider.bounds.min, bottomCollider.bounds.max, groundMask).Length>0;
        if (!origin_grounded && origin_grounded != is_grounded){
            body.linearVelocity = new Vector2(0, 0);
        }
        animator.SetBool("isJumping", !is_grounded);
    }
}
