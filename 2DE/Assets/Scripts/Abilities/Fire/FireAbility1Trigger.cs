using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility1Trigger : MonoBehaviour
{
    readonly float damage = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            HealthComponent playerHealth = collision.GetComponent<HealthComponent>();
            playerHealth.TakeHealing(damage / 2);
        }
        if (collision.CompareTag("Enemy"))
        {
            HealthComponent enemyHealth = collision.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
