using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    [SerializeField] CharacterMovement movement;
    float horizontal, vertical;
    private void Update()
    {
        if (StepByStepSystem.IsMakeStep)
            return;
        horizontal = Mathf.Clamp(Input.GetAxis("Horizontal")*1000,-1,1);
        vertical = Mathf.Clamp(Input.GetAxis("Vertical") * 1000, -1, 1);       
        if (horizontal != 0 || vertical != 0)
        {
            SetAction(movement.Action, new Vector2Int(Mathf.CeilToInt(vertical), Mathf.CeilToInt(-horizontal)));
            StepByStepSystem.GoStep();
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
