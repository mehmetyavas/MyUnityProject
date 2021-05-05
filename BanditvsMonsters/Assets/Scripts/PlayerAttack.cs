using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackManager
{
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
