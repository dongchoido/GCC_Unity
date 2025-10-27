using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float moveSpeed;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float attackRange =1f;
    Vector2 direction;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(float x, float y)
    {
        direction = new Vector2(x, y).normalized;
        rb.velocity = moveSpeed * direction;
        HandleRotation();
    }
    private void HandleRotation()
    {
        if (direction != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float newAngle = Mathf.LerpAngle(
                rb.rotation,
                targetAngle,
                rotationSpeed * Time.fixedDeltaTime
            );
            rb.MoveRotation(newAngle);
        }
    }

    public void Attack()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D col in cols)
        {
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeHit(col.transform.position - transform.position);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            ITrigger objectTrigger = collision.GetComponent<ITrigger>();
            if (objectTrigger != null)
            {
                objectTrigger.OnTriggerObj();
            }
        }
        if(collision.CompareTag("Items"))
        {
            IPickable pickable = collision.GetComponent<IPickable>();
            if (pickable != null)
            {
                pickable.OnPickup();
            }
        }
    }

    public void UpdateSpeed(float val)
    {
        moveSpeed = val;
    }
    public float GetSpeed() => moveSpeed;
}
