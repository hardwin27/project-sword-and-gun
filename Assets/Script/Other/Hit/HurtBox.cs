using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HurtBox : MonoBehaviour, IHurtBox
{
    [SerializeField] private bool _active;
    [SerializeField] private GameObject _owner;
    [SerializeField] private IHurtResponder _hurtResponder;
    
    public bool Active { get { return _active; } }

    public GameObject Owner { get { return _owner; } }

    public Transform HurtBoxTransform { get { return transform; } }

    public IHurtResponder HurtResponder { get { return _hurtResponder; } set { _hurtResponder = value; } }

    public bool CheckHit(HitData hitData)
    {
        return true;
    }
}
