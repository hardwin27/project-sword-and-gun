using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterInput : MonoBehaviour
{
    [SerializeField] private CharacterBrain _characterBrain;

    private void Update()
    {
        SetAxisInput(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        if (Input.GetKeyDown(KeyCode.C))
        {
            _characterBrain.Attack();
        }
        
    }

    private void SetAxisInput(Vector2 axisInput)
    {
        _characterBrain.Move(axisInput);
    }
}
