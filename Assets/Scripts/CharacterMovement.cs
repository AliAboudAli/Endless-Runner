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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
        }

        if (Input.GetKey(KeyCode.D)&& isGrounded)
        {
            rb.AddForce(Vector2.right * moveVelocity);
        }

        if (Input.GetKey(KeyCode.A)&& isGrounded)
        {
            rb.AddForce(Vector2.left * moveVelocity);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            /*anim.SetTrigger("Slide");*/
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            /*anim.SetTrigger("Idle");*/
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
