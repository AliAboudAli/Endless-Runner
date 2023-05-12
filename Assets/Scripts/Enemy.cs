using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Schadehoeveelheid die deze vijand kan toebrengen
    public float speed = 10f;
    public Rigidbody2D rb;
    public float damageAmount;

    void Start()
    {
        
    }

    // Methode die wordt aangeroepen wanneer deze vijand de speler raakt
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Zoek het Health-component op de speler
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        /*Camera.main.GetComponent<CameraBehaviour>().Shake = true;*/
        //Destroy(gameObject);

        // Controleer of de speler een Health-component heeft
        if (playerHealth != null)
        {
            // Roep de TakeDamage methode aan om schade toe te brengen aan de speler
            playerHealth.TakeDamage(damageAmount, gameObject);
        }
    }
}
