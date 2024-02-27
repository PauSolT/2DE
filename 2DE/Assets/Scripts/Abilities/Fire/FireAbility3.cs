using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility3 : Ability
{
    readonly float invlunerabilitySeconds = 0.75f;
    public override void Init()
    {
        base.Init();
        abilityName = "Fire shift";
        code = ElementCode.Fire;
        baseCooldown = 5f;
    }

    public override int UseAbility()
    {
        int result = base.UseAbility();
        if (result == 0)
        {
            base.UseAbility();
            StartCoroutine(nameof(Invulnerable));
            StartCoroutine(nameof(StartCooldown));
        }
        return result;
    }

    public IEnumerator Invulnerable()
    {
        player.PlayerHealth.FireInvulnerability = true;
        player.PlayerSprite.color = Color.red;
        yield return new WaitForSeconds(invlunerabilitySeconds);
        player.PlayerHealth.FireInvulnerability = false;
        player.PlayerSprite.color = Color.white;
    }
}
