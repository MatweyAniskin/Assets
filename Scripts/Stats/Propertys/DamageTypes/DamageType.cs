using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageType : PropertyType
{    
    public abstract void UsingType(float value, Stats stats);    
}
