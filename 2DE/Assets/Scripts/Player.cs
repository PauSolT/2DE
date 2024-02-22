using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Element[] elements;
    public Element[] Elements { get => elements; }

    void Start()
    {
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
