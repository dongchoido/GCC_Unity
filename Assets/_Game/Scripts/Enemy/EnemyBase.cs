using System.ComponentModel.Design;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected float health;
    protected float maxHealth = 100f;
    protected float speed = 3f;
    protected float maxSpeed;
    protected bool isDead = false;
    protected Rigidbody2D rb;
    protected Transform playerTransform;
    protected abstract void HandleMove();
    protected abstract void HanldeAttack();
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    protected virtual void Start()
    {
        health = maxHealth;
        playerTransform = InputManager.instance.PlayerTransform();
    }
    protected virtual void FixedUpdate()
    {
        if (isDead) return;
        HandleMove();
        HanldeAttack();
    }
    protected virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) isDead = true;
    }
    protected virtual void MoveTo(Vector2 pos)
    {
        Vector2 currentPos = rb.position;
        Vector2 newPos = Vector2.MoveTowards(currentPos, pos, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
