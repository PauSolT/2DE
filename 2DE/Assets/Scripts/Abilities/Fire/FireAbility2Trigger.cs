using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility2Trigger : MonoBehaviour
{
    readonly float damagePerSecond = 4f;
    readonly float interval = 0.25f;
    float currentInterval = 0.25f;

    readonly private List<HealthComponent> enemies = new();
    private HealthComponent player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<HealthComponent>();
        }
        if (collision.CompareTag("Enemy"))
        {
            enemies.Add(collision.GetComponent<HealthComponent>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
        }
        if (collision.CompareTag("Enemy"))
        {
            enemies.Remove(collision.GetComponent<HealthComponent>());
        }
    }

    private void FixedUpdate()
    {
        if (currentInterval > 0f)
        {
            currentInterval -= Time.deltaTime;
        } else if (currentInterval <= 0f)
        {
            foreach (HealthComponent enemy in enemies.ToArray())
            {
                enemy.TakeDamage(damagePerSecond * interval);
            }
            if(player)
            {
                player.TakeHealing(damagePerSecond * (interval * 2f));
            }
        }
    }
}
