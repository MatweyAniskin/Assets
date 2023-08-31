using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageType : EffectType
{    
    public abstract void UsingType(float value, Stats stats);    
}
