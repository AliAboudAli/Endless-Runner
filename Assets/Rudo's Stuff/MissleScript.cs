using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MissleScript : MonoBehaviour
{
    float timeToLive = 3;
    public GameObject explosion;
    public Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        if (timeToLive < 0)
        {
            die();
        }
    }
    void die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1, gameObject);
            die();
        }
    }
}
