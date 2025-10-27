using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : EnemyBase
{
    [SerializeField] List<Vector2> patrolPoints;
    public int currentPoint = 0;
    protected override void HandleMove()
    {
        if (patrolPoints.Count > 1)
            MoveTo(patrolPoints[currentPoint]);
        if(Vector2.Distance(patrolPoints[currentPoint],transform.position)<0.1f)
        {
            currentPoint = NextPoint();
        }
    }

    protected override void HanldeAttack()
    {

    }
    
    private int NextPoint()
    {
        if (currentPoint == patrolPoints.Count - 1)
        {
            return 0;
        }
        return currentPoint + 1;
    }

}
