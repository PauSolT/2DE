using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    protected string abilityName = "";
    protected ElementCode code = ElementCode.NumOfElementCodes;
    protected Player player;

    public virtual void Init()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void Log()
    {
        Debug.Log("Ability: " + abilityName + "\n" +
            "Element: " + code.ToString());
    }


    public virtual void UseAbility(Collider2D collider)
    {

    }
}
