using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtBox
{
    public bool Active { get; }
    public GameObject Owner { get; }
    public Transform HurtBoxTransform { get; }
    public IHurtResponder HurtResponder { set; get; }

    public bool CheckHit(HitData hitData);
}
