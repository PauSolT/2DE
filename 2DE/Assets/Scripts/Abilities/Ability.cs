using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    protected string abilityName = "";
    protected ElementCode code = ElementCode.NumOfElementCodes;
    protected Player player;
    protected float baseCooldown;
    protected float currentCooldown;
    protected bool isOnCooldown;


    public virtual void Init()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        isOnCooldown = false;
    }

    public void Log()
    {
        Debug.Log("Ability: " + abilityName + "\n" +
            "Element: " + code.ToString() + "\n" +
            "Base cooldown: " + baseCooldown);
    }


    public virtual int UseAbility()
    {
        if (isOnCooldown)
        {
            return 1;
        } else
        {
            return 0;
        }
    }

    public virtual IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(baseCooldown);
        isOnCooldown = false;
    }
}
