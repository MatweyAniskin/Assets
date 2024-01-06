using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Physical", menuName = "EffectsType/PhysicalDamage")]
public class PhysicalDamageType : DamageType
{   
    public override void UsingType(float value, Stats stats)
    {
       // stats.Damage(value, this);
    }
}
