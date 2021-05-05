using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    Rigidbody2D playerRB;
     Animator animator;
    public bool isGrounded = true;
    public float moveSpeed = 4f;
    public float jumpSpeed = 5f;
    bool facingRight = false;
    private void Awake()
    {
       
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void Movement()
    {
        //horizontal move
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        //animator.SetFloat("MoveSpeed", Mathf.Abs(playerRB.velocity.x));
        animator.SetFloat("MoveSpeed", Mathf.Abs(playerRB.velocity.x));
        //flipSide
        if (playerRB.velocity.x < 0 && !facingRight)
        {
            FlipFace();
        }
        if (playerRB.velocity.x > 0 && facingRight)
        {
            FlipFace();
        }
        //jump and is grounded
        IsGrounded();
    }
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void IsGrounded()
    {
        if (isGrounded == true)
        {
            Jump();
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerRB.velocity = Vector2.up * jumpSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
