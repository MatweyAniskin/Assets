using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    [SerializeField] PropertyValue damageValue;
    public override string Description
    {
        get
        {
            string des = string.Empty;

            return des;
        }
    }

    public override PropertyValue[] GetEffectsValues() //Unit
    {
        return new PropertyValue[1] {damageValue };
    }

    public override string ToString()
    {
        return keyName;
    }
}
