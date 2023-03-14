using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void Attack()
    {
        _weapon.Attack();
    }
}
