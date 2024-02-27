using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility2 : Ability
{
    [SerializeField]
    GameObject prefab;
    Vector3 offset;

    public override void Init()
    {
        base.Init();
        abilityName = "Fire pool";
        code = ElementCode.Fire;
        offset = (4f * player.transform.right) + Vector3.down ;
        baseCooldown = 20f;
    }


    public override int UseAbility()
    {
        int result = base.UseAbility();
        if (result == 0)
        {
            Object ability = GameObject.Instantiate(prefab,
            player.transform.position + offset,
            Quaternion.identity);
            GameObject.Destroy(ability, 4.5f);
            StartCoroutine(nameof(StartCooldown));
        }
        return result;
    }
}
