using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    [SerializeField] StepAction movement;
    int horizontal, vertical;
    private void Update()
    {
        if (StepByStepSystem.IsMakeStep)
        {           
            return;
        }

        if (Input.GetKey(KeyCode.D)) horizontal = 1;
        if (Input.GetKey(KeyCode.A)) horizontal = -1;        
        if (Input.GetKey(KeyCode.W)) vertical = 1;
        if (Input.GetKey(KeyCode.S)) vertical = -1;
        if (horizontal != 0 || vertical != 0)
        {
            SetAction(movement.Action, new Vector2Int(vertical, -horizontal));
            StepByStepSystem.GoStep();
            horizontal = 0;
            vertical = 0;
        }
    }
    public override void OnDelete()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        //throw new System.NotImplementedException();
    }
}
