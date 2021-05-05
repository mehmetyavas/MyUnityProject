using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControlManager
{

    AttackManager attackManager;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GetComponent<AttackManager>().muzzle = transform.GetChild(1);
        attackManager = GetComponent<AttackManager>();
    }
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Movement();
        attackManager.AttackTime();
    }
    internal void Anim()
    {
        animator.SetFloat("MoveSpeed", Mathf.Abs(rigidbody2D.velocity.x));
    }
    

}
