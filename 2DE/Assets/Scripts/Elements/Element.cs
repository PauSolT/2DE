using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
    string elementName = "";
    ElementCode code = ElementCode.NumOfElementCodes;

    List<Ability> abilities = new();

    public Element(string eleName, ElementCode eleCode)
    {
        elementName = eleName;
        code = eleCode;
    }

    public virtual void Init()
    {

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