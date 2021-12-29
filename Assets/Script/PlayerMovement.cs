using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public GameObject rayOrigin;
    public float rayCheckDistance;
    public float gravityScale = 1.5f;
    private bool facingRight = true;
    private float x = 0f;
    [SerializeField] private LayerMask groundLayer;
    public Animator animator;
    Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        //Debug.DrawRay(rayOrigin.transform.position, Vector2.down * rayCheckDistance, Color.red);
        x = Input.GetAxis("Horizontal");
        flip();
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isGrounded())
            {
                //rb.AddForce(Vector2.up * jump, ForceMode2D.Force);
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isGrounded())
            {
                animator.SetTrigger("attack");
            }
        }

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        if (isGrounded())
        {
            animator.SetBool("grounded", true);
        } else
        {
            animator.SetBool("grounded", false);
        }
        //Debug.Log(x);
        //float x = Input.GetAxis("Horizontal");
        //flip();
        //rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);
    }

    void flip()
    {
        if ((Input.GetAxis("Horizontal") < 0 && facingRight) || (Input.GetAxis("Horizontal") > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance, groundLayer);
        return hit.collider != null;
    }

    public void Die()
    {
        isDead = true;
        animator.SetBool("die", true);
        animator.SetTrigger("hurt");
    }

    private void UpdateAnimation()
    {
        if (x > 0f)
        {
            animator.SetBool("running", true);
        }
        else if (x < 0f)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }
    }
}
