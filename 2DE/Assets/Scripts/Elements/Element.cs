using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
    protected string elementName = "";
    protected ElementCode code = ElementCode.NumOfElementCodes;
    protected ElementStatus status = ElementStatus.NumOfElementStatus;

    protected List<Ability> abilities = new();

    public virtual void Init()
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