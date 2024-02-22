using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    float maxHealth = 10f;
    float currentHealth = 10f;

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage for " + damage);
        currentHealth -= damage;
        if (CheckIfNoHealth())
        {
            Die();
        }
    }

    public void TakeHealing(float healing)
    {
        Debug.Log("Healing for " + healing);
        currentHealth += healing;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool CheckIfNoHealth()
    {
        return currentHealth <= 0;
    }

    void Die()
    {
        Destroy(gameObject);
    }


}
