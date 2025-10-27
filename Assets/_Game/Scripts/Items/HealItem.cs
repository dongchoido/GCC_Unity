using UnityEngine;

public class HealItem : MonoBehaviour, IPickable
{
    [SerializeField] float healthBuffValue = 5f;
    public void OnPickup()
    {
        DataManager.instance.HealthBuff(healthBuffValue);
        gameObject.SetActive(false);
    }
}
