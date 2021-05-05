using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    HealthManager getDamage;
    public float lifeTime;
    public int bulletDamage;
    float lifeTimeHit =0.1f;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifeTime);
        
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, lifeTimeHit);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("we hit! " + other.collider.name);
            other.collider.GetComponent<HealthManager>().TakeDamage(bulletDamage);
        }
    }

}
