using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float popupTime;
    [SerializeField] float force = 3f;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeHit(Vector2 dir)
    {
        rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);
    }
}
