using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapopnAnimationEvent : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void AttackFinished()
    {
        _weapon.AttackFinish();
    }
}
