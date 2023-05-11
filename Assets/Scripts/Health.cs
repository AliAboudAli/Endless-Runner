using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 5;
    public float currentHealth;
    public float healthRegenRate = 1f;
    [SerializeField] private float healthRegenAmount;
    [SerializeField] private float invincibilityTime;
    float timeSinceLastHeal = 0;
    float invincible;
    bool takesDamage = true;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount, GameObject attacker)
    {
        if (takesDamage)
        {
            if (attacker.CompareTag("Enemy"))
            {
                currentHealth -= damageAmount;
                timeSinceLastHeal = 0;
                invincible = 0;
            }
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Debug.Log("Player has died!");
        gameObject.GetComponent<ScoreSaver>().saveEnd();
        FindObjectOfType<SceneLoader>().LoadScene("pepijn");
    }

    void RegenerateHealth()
    {
        timeSinceLastHeal += Time.deltaTime;
        if (timeSinceLastHeal > healthRegenRate)
        {
            currentHealth += healthRegenAmount;
            timeSinceLastHeal= 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth= maxHealth;
        }
    }

    void InvincibilityTime()
    {
        invincible += Time.deltaTime;
        if (invincible > 0 && invincible < invincibilityTime)
        {
            takesDamage = false;
        }
        else
        {
            takesDamage = true;
        }
    }

    void Update()
    {
        RegenerateHealth();
        InvincibilityTime();
    }
}

