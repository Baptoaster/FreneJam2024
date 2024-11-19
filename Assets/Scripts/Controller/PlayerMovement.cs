using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //Will handle player speed, jumps
    public PlayerInput pI;
    public Rigidbody2D rb;
    public bool isGrounded;
    public float speed = 5f;
    public float jumpForce = 2f;
    public Animator anim;
    public UnityEvent goLeft;
    public UnityEvent goRight;

    public bool isMirrored;

    private Vector3 movement;

    public void MoveUpdate()
    {
        HorizontalMovement();
        GroundCheck();
        
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        if (rb.velocity.magnitude > 0.5)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    public void HorizontalMovement()
    {
        if (isMirrored)
        {
            movement.x = -speed * pI.HorizontalInput();
        }
        else
        {
            movement.x = speed * pI.HorizontalInput();
        }
        
        if (movement.x < 0 )
        {
            goLeft.Invoke();
        }

        if (movement.x > 0 )
        {
            goRight.Invoke();
        }
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position - new Vector3(0, 1.1f, 0), new Vector2(0.6f, 0.2f), 0, -Vector2.up, 0.2f, 1);

        if (hit)
        {
            isGrounded = true;
        }
        else { isGrounded = false; }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
