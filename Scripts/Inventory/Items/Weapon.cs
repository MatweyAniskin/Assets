using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    [SerializeField] PropertyValue damageValue;
    [SerializeField] Modify prefixModify;
    [SerializeField] Modify suffixModify;
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
        List<PropertyValue> values = new List<PropertyValue>();
        values.Add(damageValue);
        if (prefixModify != null)
            values.Add(prefixModify.PropertyValue);
        if (suffixModify != null)
            values.Add(suffixModify.PropertyValue);
        return values.ToArray();
    }

    public override string ToString()
    {
        string res = string.Empty;
        if (prefixModify != null)
            res =$"{prefixModify} ";
        res += keyName; //Localization
        if(suffixModify != null)
            res += $" {suffixModify}";
        return res;
    }
}
