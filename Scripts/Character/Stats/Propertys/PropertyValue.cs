using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PropertyValue
{
    [SerializeField] PropertyType effectType;
    [SerializeField] int value;
    public Sprite Icon => effectType.Icon;
    public PropertyType EffectType => effectType;
    public int Value
    {
        get => value;
        set => this.value = value;
    }
    public override string ToString() => effectType.ToString();    

    public static bool operator ==(PropertyValue left, PropertyValue right) => left.effectType == right.effectType;
    public static bool operator !=(PropertyValue left, PropertyValue right) => left.effectType != right.effectType;
    public static bool operator ==(PropertyValue left, PropertyType right) => left.effectType == right;
    public static bool operator !=(PropertyValue left, PropertyType right) => left.effectType != right;
}
