using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment",menuName = "Items/Equipment")]
public class Equipment : Item
{
    public override string Description => throw new System.NotImplementedException();

    public override string ToString()
    {
        return keyName;
    }
}
