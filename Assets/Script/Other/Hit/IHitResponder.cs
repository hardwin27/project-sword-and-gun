using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitResponder
{
    public int Damage { get; }

    public bool CheckHit(HitData hitData);
    public void Response(HitData hitData);
}
