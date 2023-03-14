using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    [SerializeField] private Transform _visualTransform;
    private Vector3 _initialScale;

    private void OnEnable()
    {
        _initialScale = _visualTransform.localScale;
    }

    public void FaceToDirection(float faceDirection)
    {
        if (faceDirection == 0f)
        {
            return;
        }
        _visualTransform.localScale = new Vector3(_initialScale.x * Mathf.Sign(faceDirection), _initialScale.y, _initialScale.z);
    }
}
