using UnityEngine;

public class ItemOnTray : MonoBehaviour,IDragable
{
     bool x= true;
    bool dragable = true;
    public void OnDrag()
    {
        if(dragable)
        transform.position = InputManager.instance.MousePos();
    }
    public void OnDrop()
    {
    
        if (dragable)
            x=!InputManager.instance.CheckDropItem();
        dragable = x;
    }
}
