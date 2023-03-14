using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour, IHurtResponder
{
    [SerializeField] private float _health;
    [SerializeField] private float _attackPower;

    [SerializeField] private Rigidbody2D _body;
    private List<HurtBox> _hurtBoxes = new List<HurtBox>();

    private void Awake()
    {
        
    }

    private void InitiateHurtBoxes()
    {
        _hurtBoxes = new List<HurtBox>(GetComponentsInChildren<HurtBox>());
        foreach (HurtBox hurtBox in _hurtBoxes)
        {
            hurtBox.HurtResponder = this;
        }
    }

    public bool CheckHit(HitData hitData)
    {
        return true;
    }

    public void Response(HitData hitData)
    {
        Debug.Log($"{gameObject.name} HITTED");
    }
}
