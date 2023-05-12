using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    public float moveSpeed;
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float edgeCheckDistance;
    public Transform edgeCheck;

    private Rigidbody2D rb;
    private bool isFacingLeft = true;
    float flipCooldown = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // move the enemy left
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        flipCooldown -= Time.deltaTime;
        // check if there's ground below the enemy
       // bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

       // if (!isGrounded || CheckEdge())
      //  {
            // if there's no ground below the enemy or there's an edge, turn it around
            // Flip();
       // }
    }

    //bool CheckEdge()
    //{
        // check if there's an edge in front of the enemy
       // RaycastHit2D edgeHit = Physics2D.Raycast(edgeCheck.position, Vector2.left, edgeCheckDistance, whatIsGround);

      //  return edgeHit.collider != null;
    //}

    public void Flip()
    {
        if (flipCooldown <= 0)
        {
            // flip the enemy horizontally
            isFacingLeft = !isFacingLeft;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
            flipCooldown = 1;
        }
    }

    // Schadehoeveelheid die deze vijand kan toebrengen
    public float damageAmount;

    // Methode die wordt aangeroepen wanneer deze vijand de speler raakt
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zoek het Health-component op de speler
        Health playerHealth = collision.gameObject.GetComponent<Health>();

        // Controleer of de speler een Health-component heeft
        if (playerHealth != null)
        {
            // Roep de TakeDamage methode aan om schade toe te brengen aan de speler
            playerHealth.TakeDamage(damageAmount, gameObject);
            Destroy(gameObject);
        }
    }
}