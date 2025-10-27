using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour, ITrigger
{
    public void OnTriggerObj()
    {
        Debug.Log("Tron");
    }
}
