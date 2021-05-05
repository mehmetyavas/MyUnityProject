using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthManager
{


    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

    }
    public override void Die(int damage)
    {
        
            base.Die(damage);
        


    }
    public void DestroyDelay()
    {
        print("Died");
        Destroy(gameObject);

    }
   
}
