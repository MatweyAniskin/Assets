using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : CharacterBehaviour
{
    StepAction[] stepActions;

    public override void OnStart()
    {
        stepActions = GetComponents<StepAction>();
    }
    public override void OnDelete()
    {
        throw new System.NotImplementedException();
    }

    
}
