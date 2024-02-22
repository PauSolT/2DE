using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility1 : Ability
{
    float damage = 10f;
    [SerializeField]
    GameObject prefab;

    public override void UseAbility(Collider2D collider)
    {
        Instantiate(prefab, player.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Do damage
        } 
        else if (collision.CompareTag("Player"))
        {
            //Heal
        }
    }
}
