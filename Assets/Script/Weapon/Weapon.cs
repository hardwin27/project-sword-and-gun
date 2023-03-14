using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _isAttacking = false;

    public virtual void Attack()
    {
        if (!_isAttacking)
        {
            _animator.SetTrigger("Attack");
            _isAttacking = true;
        }
    }

    public virtual void AttackFinish()
    {
        _isAttacking = false;
    }
}
