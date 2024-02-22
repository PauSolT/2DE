using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<Element> elements = new();


    void Start()
    {
        elements.Add(new FireElement());

        foreach (Element element in elements)
        {
            element.Init();
            element.Log();
        }

    }
   
}
