using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeutralState", menuName = "State/Neutral")]
public class StateNeutral : State
{
    public override bool Rule(Stats stats, NpcBehaviour behaviour) => behaviour.AttackTarget is null;    
}
