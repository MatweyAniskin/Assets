using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleDefence", menuName = "EffectsType/SimpleDefence")]
public class SimpleDefenceType : DefenceType
{
    public override float ValueCalculate(float value) => (0.05f * value) / (1f + 0.05f * Mathf.Abs(value)) * (0.052f * value) / (0.9f + 0.048f * Mathf.Abs(value));
    public override string ValueLine(float value) => $"{Convert.ToInt32(ValueCalculate(value) * 100)}%";
}
