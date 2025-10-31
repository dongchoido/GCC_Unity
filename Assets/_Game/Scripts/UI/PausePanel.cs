using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PausePanel : UIBase
{
    public void Popup(bool isShowing)
    {
        base.Popup(0.3f,isShowing);
    }
}
