using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitDetector
{
    public IHitResponder HitResponder { set; get; }
    public void CheckHit();
}
