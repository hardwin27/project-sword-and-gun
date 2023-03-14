using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData
{
    [SerializeField] private int _damage;
    [SerializeField] private Vector3 _hitPoint;
    [SerializeField] private IHurtBox _hurtBox;
    [SerializeField] private IHitDetector _hitDetector;

    public int Damage 
    { 
        set { _damage = value; }
        get { return _damage; }
    }

    public Vector3 HitPoint
    {
        set { _hitPoint = value; }
        get { return _hitPoint; }
    }

    public IHurtBox HurtBox
    {
        set { _hurtBox = value; }
        get { return _hurtBox; }
    }

    public IHitDetector HitDetector
    {
        set { _hitDetector = value; }
        get { return _hitDetector; }
    }

    public bool Validate()
    {
        if (HurtBox != null)
        {
            if (HurtBox.CheckHit(this))
            {
                if (HurtBox.HurtResponder == null || HurtBox.HurtResponder.CheckHit(this))
                {
                    if (HitDetector.HitResponder == null || HitDetector.HitResponder.CheckHit(this))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
