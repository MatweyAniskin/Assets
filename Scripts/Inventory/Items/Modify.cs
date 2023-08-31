using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modify : ScriptableObject
{
    [SerializeField] protected string keyName;

    public abstract void SetStats(Stats stats);    
    public override string ToString() => keyName;    
}
