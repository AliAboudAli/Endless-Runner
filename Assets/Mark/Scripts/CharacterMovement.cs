using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float jump;
    public float moveVelocity;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Animator anim;
    bool facingRight = true;
    public Transform rayPoint;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 20f)
        {
            rb.AddForce(Vector2.left * 1);
        }

            RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, -Vector2.up, 0.1f);
        if (hit.collider != null)
        {
            print(hit.collider.name);
            if (hit.collider.tag == "Ground")
            {
                isGrounded= true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(transform.position, -transform.up , Color.blue , 10f);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
            anim.SetTrigger("jump");
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < 20f)
            {
                rb.AddForce(Vector2.right * moveVelocity);
                flip();
                anim.SetTrigger("Run");
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -20f)
            {
                rb.AddForce(Vector2.left * moveVelocity);
                flip();
                anim.SetTrigger("Run");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Slide");
        }

        if (Input.GetKeyUp(KeyCode.S) && isGrounded) 
        {
            anim.SetTrigger("Idle");
        }


    }
}
