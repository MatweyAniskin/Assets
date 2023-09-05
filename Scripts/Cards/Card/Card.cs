using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    [SerializeField] string keyName;

    [SerializeField] string description;
    [SerializeField] int energy = 1;
    public int Energy => energy;
    public abstract bool UseCard(Stats casterStats, Stats enemyStats);    
    public override string ToString() => keyName;    
}
