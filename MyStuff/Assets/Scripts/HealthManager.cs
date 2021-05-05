using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    Animator animator;
    Slider slider;
    public int health = 100;
    int currentHealth;
   
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        slider = GetComponent<Slider>();
        currentHealth = health;
        
    }
    
    public virtual void TakeDamage(int damage)
    {

        currentHealth -= damage;

        slider.value = currentHealth;
        Debug.Log(slider.value);
        animator.SetTrigger("GetHurt");
        if (currentHealth <= 0)
        {
            Die(damage);
            animator.SetBool("IsDead", true);
        }

    }
    
    public virtual void Die(int damage)
    {
        if (currentHealth -damage <= 0)
        {
            slider.value = 0;
            DestroyCollider();
        }
    }
    void DestroyCollider()
    {
        Destroy(gameObject.GetComponent<Collider2D>());
        gameObject.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
