using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 10f;
    [SerializeField]
    float currentHealth = 10f;

    bool fireInvulnerability = false;
    public bool FireInvulnerability { get => fireInvulnerability; set => fireInvulnerability = value; }

    public float TakeDamage(float damage)
    {
        if (fireInvulnerability)
        {
            return TakeHealing(damage * 0.25f);
        } else
        {
            float healthBeforeDamage = currentHealth;
            float healthAfterDamage;
            currentHealth -= damage;
            healthAfterDamage = currentHealth;
            if (currentHealth <= 0f)
            {
                Die();
            }
            Debug.Log(currentHealth);
            return healthBeforeDamage - healthAfterDamage;
        }
    }

    public float TakeHealing(float healing)
    {
        float healthBeforeHealing = currentHealth;
        currentHealth += healing;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        float healthAfterHealing = currentHealth;
        return healthAfterHealing - healthBeforeHealing;
    }

    void Die()
    {
        Destroy(gameObject);
    }


}
