using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseState", menuName = "State/Chase")]
public class StateChase : State
{
    public override bool Rule(Stats stats, NpcBehaviour behaviour) => behaviour.IsTargeting;    
}
