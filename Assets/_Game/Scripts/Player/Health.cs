using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth;
    public void UpdateHealth(float val)
    {
        currentHealth = val;
    }
}
