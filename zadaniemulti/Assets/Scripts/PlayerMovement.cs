using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{

    public Animator animator;
    bool dirToRight = true;
    public Rigidbody2D rb;
    public float runSpeed = 5f;
   


    void Update()
    {
        if (!isLocalPlayer) return;
        Movement();
    }

    void Flip()
    {   
        dirToRight = !dirToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2(horizontalMove * runSpeed, rb.velocity.y);
        if (horizontalMove > 0 && dirToRight)
        {
            Flip();
        }
        if (horizontalMove < 0 && !dirToRight)
        {
            Flip();
        }
    }
}
