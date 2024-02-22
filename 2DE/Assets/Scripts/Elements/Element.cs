using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    protected string elementName = "";
    protected ElementCode code = ElementCode.NumOfElementCodes;
    protected ElementStatus status = ElementStatus.NumOfElementStatus;

    [SerializeField]
    protected Ability[] abilities;
    public Ability[] Abilities { get => abilities; }


    public virtual void Init()
    {
        PopulateAbilities();
    }

    protected virtual void PopulateAbilities()
    {

    }

    public void Log()
    {
        Debug.Log("Ability: " + elementName + "\n" +
            "Element: " + code.ToString() + "\n" +
            "Status: " + status.ToString());

    }
}

public enum ElementCode
{
    Fire,
    Water,
    Air,
    Ground,
    NumOfElementCodes
}

public enum ElementStatus
{
    Ready,
    Using,
    Unavaiable,
    NumOfElementStatus
}