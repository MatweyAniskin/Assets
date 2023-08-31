using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenceType : EffectType
{
    [SerializeField] EffectType contrType;
    public EffectType ContrType => contrType;    
    public float ContrCalck(float damage, float defence) => ValueCalculate(defence) * damage;

    public static bool operator ==(DefenceType a, DamageType b) => a.contrType == b;
    public static bool operator !=(DefenceType a, DamageType b) => a.contrType != b;
}
