using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ObjectTrigger
{
    public override void OnTrigger()
    {
        base.OnTrigger();
        Debug.Log("Box");
    }
}
