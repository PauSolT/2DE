using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElement : Element
{
    public override void Init()
    {
        base.Init();
        elementName = "Fire";
        code = ElementCode.Fire;
        status = ElementStatus.Ready;
    }


}
