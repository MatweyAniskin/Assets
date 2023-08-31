using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    [SerializeField] EffectType damageType;
    public override string Description
    {
        get
        {
            string des = string.Empty;

            return des;
        }
    }

    public override string ToString()
    {
        return keyName;
    }
}
