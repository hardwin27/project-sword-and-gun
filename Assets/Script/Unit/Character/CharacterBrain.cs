using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrain : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CharacterVisual _characterVisual;
    [SerializeField] private CharacterCombat _characterCombat;

    public void Move(Vector2 moveDirection)
    {
        _characterMovement.MoveInput(moveDirection);
        _characterVisual.FaceToDirection(moveDirection.x);
    }

    public void Attack()
    {
        _characterCombat.Attack();
    }
}
