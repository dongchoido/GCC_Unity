using UnityEngine;

public class SpeedBuffItem : MonoBehaviour,IPickable
{
    [SerializeField] float speedBuffValue = 3f;

    public void OnPickup()
    {
        DataManager.instance.SpeedBuff(speedBuffValue);
        gameObject.SetActive(false);
    }
}
