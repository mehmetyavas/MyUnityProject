using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackManager
{
    CircleCollider2D detectorCD;
   

    private void Awake()
    {
        detectorCD = GetComponent<CircleCollider2D>();
        DetectPlayer(detectorCD);
        animator = GetComponent<Animator>();
    }

    internal override void AttackTime()
    {
        if (Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            Attack(layers);
        }
    }
    void DetectPlayer(CircleCollider2D detectorCD)
    {
        detectorCD.radius = attackRange;
        detectorCD.offset = new Vector2(-.331f, .128f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        try
        {
            AttackTime();
        }
        catch (Exception e)
        {

            throw;
        }
        

    }

}
