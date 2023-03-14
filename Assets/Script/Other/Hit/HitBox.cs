using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour, IHitDetector
{
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private IHitResponder _hitResponder;

    public IHitResponder HitResponder { get { return _hitResponder; } set { _hitResponder = value; } }

    private List<Collider2D> _detectedColliders = new List<Collider2D>();

    public void CheckHit()
    {
        HitData hitData = null;

        foreach (Collider2D detectedCollider in _detectedColliders)
        {
            if (detectedCollider.TryGetComponent(out IHurtBox detectedHurtBox))
            {
                if (detectedHurtBox.Active)
                {
                    hitData = new HitData
                    {
                        Damage = (HitResponder == null) ? 0 : HitResponder.Damage,
                        HitPoint = detectedCollider.ClosestPoint(transform.position),
                        HurtBox = detectedHurtBox,
                        HitDetector = this,
                    };

                    if (hitData.Validate())
                    {
                        hitData.HitDetector.HitResponder?.Response(hitData);
                        hitData.HurtBox.HurtResponder?.Response(hitData);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _detectedColliders.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _detectedColliders.Remove(collision);
    }
}
