using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Element[] elements;
    public Element[] Elements { get => elements; }

    HealthComponent playerHealth;
    public HealthComponent PlayerHealth { get => playerHealth; }

    SpriteRenderer playerSprite;
    public SpriteRenderer PlayerSprite { get => playerSprite; }

    void Start()
    {
        playerHealth = GetComponent<HealthComponent>();
        playerSprite = GetComponent<SpriteRenderer>();
        elements = GetComponentsInChildren<Element>();

        foreach (Element element in elements)
        {
            element.Init();
            foreach (Ability ability in element.Abilities)
            {
                ability.Init();
            }
        }

    }
   
}
