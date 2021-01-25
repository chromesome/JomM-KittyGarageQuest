using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;

    public float jumpForce;
    public float jumpTime;
    float jumpTimeCounter;
    bool isJumping;

    public LayerMask groundLayer;
    [SerializeField]
    float speed;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    bool IsGrounded()
    {
        bool isGrounded = false;
        float extraHeightText = 1f;
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeightText, groundLayer);

        Color rayColor;
        if(hit.collider != null)
        {
            rayColor = Color.green;
            isGrounded = true;
        }
        else
        {
            rayColor = Color.red;
        }
        return isGrounded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
                 if (collision.CompareTag("Breakable"))
        {
            BreakableItem breakableItem = collision.GetComponent<BreakableItem>();

            if (breakableItem != null)
            {
                breakableItem.BreakIt();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
