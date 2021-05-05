using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Transform bullet;
    public float bulletSpeed;
    public float attackRange;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public int damage=10;
    public int magazine=5;
    public Transform muzzle;
    public LayerMask enemyLayers;
    public Transform attackPos;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        muzzle = transform.GetChild(3);

    }
   
    
    private void Update()
    {
        AttackTime();
        
    }
    private void FixedUpdate()
    {
        GetComponent<PlayerController>().Movement();

    }
    void Attack()
    {
        // play an attack animation
        animator.SetTrigger("Attack");
        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);
        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //print("we stay!");
        }
    }
    public void AttackTime()
    {
        if (Time.time > nextAttackTime)
        {
                if (Input.GetKey(KeyCode.Space))
                {
                    Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            BulletMagazine();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPos == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }
    public void SkillBullet()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Transform tempBullet;
            tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
            magazine--;
            
        }
    }
    void BulletMagazine() 
    {
        if (magazine>0)
        {
            SkillBullet();
        }
    }
    
}
