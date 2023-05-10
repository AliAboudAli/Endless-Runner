using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public float healthRegenRate = 1f;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount, GameObject attacker)
    {
        if (attacker.CompareTag("Enemy"))
        {
            currentHealth -= damageAmount;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player has died!");
        // Voor de gameover scene
    }

    void RegenerateHealth()
    {
        if (currentHealth >= maxHealth)
        {
            return;
        }
        currentHealth += Mathf.CeilToInt(healthRegenRate * Time.deltaTime);

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    void Update()
    {
        RegenerateHealth();
    }
}

