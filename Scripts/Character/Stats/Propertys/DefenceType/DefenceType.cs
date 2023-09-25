using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenceType : PropertyType
{
    [SerializeField] PropertyType contrType;
    public PropertyType ContrType => contrType;    
    public float ContrCalck(float damage, float defence) => ValueCalculate(defence) * damage;
    public bool IsContrEffect(PropertyType damage) => contrType = damage;    
}
