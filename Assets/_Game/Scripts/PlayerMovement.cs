using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rotationSpeed = 5f;
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
        if(direction!=Vector2.zero)
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
}
