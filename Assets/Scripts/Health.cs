using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image healthImage;
    public Sprite[] healthSprites;

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
                print("Oh no you've taken damage");
                currentHealth -= damageAmount;
                switch (currentHealth)
                {
                    case 5:
                        healthImage.sprite = healthSprites[4];
                        break;
                    case 4:
                        healthImage.sprite = healthSprites[3];
                        break;
                    case 3:
                        healthImage.sprite = healthSprites[2];
                        break;
                    case 2:
                        healthImage.sprite = healthSprites[1];
                        break;
                    case 1:
                        healthImage.sprite = healthSprites[0];
                        break;
                }
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
        FindObjectOfType<SceneLoader>().LoadScene("MainMenu");
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
        switch (currentHealth)
        {
            case 5:
                healthImage.sprite = healthSprites[4];
                break;
            case 4:
                healthImage.sprite = healthSprites[3];
                break;
            case 3:
                healthImage.sprite = healthSprites[2];
                break;
            case 2:
                healthImage.sprite = healthSprites[1];
                break;
            case 1:
                healthImage.sprite = healthSprites[0];
                break;
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

