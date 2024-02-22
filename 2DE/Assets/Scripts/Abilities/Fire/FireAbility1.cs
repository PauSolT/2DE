using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility1 : Ability
{
    readonly float damage = 10f;
    [SerializeField]
    GameObject prefab;

    public override void UseAbility(Collider2D collider)
    {
        Object ability = GameObject.Instantiate(prefab, player.transform);
        GameObject.Destroy(ability, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthComponent enemyHealth = collision.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(damage);
        } 
        else if (collision.CompareTag("Player"))
        {
            HealthComponent playerHealth = collision.GetComponent<HealthComponent>();
            playerHealth.TakeHealing(damage/2);
        }
    }
}
