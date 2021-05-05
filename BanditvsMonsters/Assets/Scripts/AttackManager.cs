using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//detectorcd,necxtattacktime,attackrate
public interface IAttackPos
{

}
public class AttackManager : MonoBehaviour
{
     
    public float nextAttackTime=0f ;
    public float attackRate =1f;
    [SerializeField] internal LayerMask layers;
    public Transform attackPos;
    public Transform muzzle;
    public float attackRange;
    internal Animator animator;
    
    

    public void Attack(LayerMask hitLayer)
    {
        // play an attack animation

        animator.SetTrigger("Attack");
        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, hitLayer);
        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we Hitt!!!" + enemy);
        }

    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPos == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    internal virtual void AttackTime()
    {
         if (Time.time > nextAttackTime)
         {
                if (Input.GetKey(KeyCode.Mouse0))
                {

                    Attack(layers);
                    nextAttackTime = Time.time + 1f / attackRate;


                }
         }
    }
    

}
