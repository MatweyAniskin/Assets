using Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageType : PropertyType
{
    [SerializeField] AnimationArgument animationArgument;
    public AnimationArgument AnimationArgument => animationArgument;
    public abstract void UsingType(float value, Stats stats);    
}
