using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    internal new Rigidbody2D rigidbody2D;
    internal Animator animator;
    public bool isGrounded;
    public float moveSpeed;
    public float jumpSpeed;
    private bool facingRight = false;

   

    public void Movement()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidbody2D.velocity.y);
        //Running Animation
        GetComponent<PlayerController>().Anim();
        //Flipface
        if (rigidbody2D.velocity.x < 0 && !facingRight)
        {
            FlipFace();
        }
        if (rigidbody2D.velocity.x > 0 && facingRight)
        {
            FlipFace();
        }
        //Jump
        GroundCheck();
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void GroundCheck()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            rigidbody2D.velocity = Vector2.up * jumpSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
