using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Modify", menuName = "Item/Modify")]
public class Modify : ScriptableObject
{
    [SerializeField] protected string keyName;
    [SerializeField] protected PropertyValue propertyValue;

    public PropertyValue PropertyValue => propertyValue;
    public override string ToString() => keyName;    
}
