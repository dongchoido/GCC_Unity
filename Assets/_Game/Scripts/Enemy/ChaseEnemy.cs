using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : EnemyBase
{
    [SerializeField] float chaseRange = 5f;
    protected override void HandleMove()
    {
        if(Vector2.Distance(transform.position,playerTransform.position)<=chaseRange)
            MoveTo(playerTransform.position);
    }

    protected override void HanldeAttack()
    {
        
    }
}
