using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    protected string abilityName = "";
    protected ElementCode code = ElementCode.NumOfElementCodes;

    public virtual void Init()
    {

    }

    public void Log()
    {
        Debug.Log("Ability: " + abilityName + "\n" +
            "Element: " + code.ToString());
    }

}
