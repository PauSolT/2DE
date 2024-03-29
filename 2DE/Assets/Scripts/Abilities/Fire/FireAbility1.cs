using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility1 : Ability
{
    [SerializeField]
    GameObject prefab;
    Vector3 offset;

    public override void Init()
    {
        base.Init();
        abilityName = "Fire fist";
        code = ElementCode.Fire;
        offset = Vector3.right * 4.5f;
        baseCooldown = 7f;
    }


    public override int UseAbility()
    {
        int result = base.UseAbility();
        if (result == 0)
        {
            Object ability = GameObject.Instantiate(prefab, 
                player.transform.position + offset,
                Quaternion.identity,
                player.transform);
            GameObject.Destroy(ability, 0.5f);
            StartCoroutine(nameof(StartCooldown));
        }
        return result;
    }

}
