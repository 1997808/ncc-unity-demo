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
    [SerializeField] private LayerMask groundLayer;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        Debug.DrawRay(rayOrigin.transform.position, Vector2.down, Color.red);
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded())
            {
                //rb.AddForce(Vector2.up * jump, ForceMode2D.Force);
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        // Debug.DrawRay(rayOrigin.transform.position, Vector2.down * 5, Color.red);
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance, groundLayer);
        return hit.collider != null;
    }
}
