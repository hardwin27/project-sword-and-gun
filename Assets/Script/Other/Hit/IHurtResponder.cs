using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtResponder
{
    public bool CheckHit(HitData hitData);
    public void Response(HitData hitData);
}
