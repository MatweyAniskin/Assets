using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    [SerializeField] StepAction movement;
    [SerializeField] StepAction skills;
    Vector2Int move;
    Vector2Int lastMove;
    private void Update()//Unit
    {
        if (StepByStepSystem.IsMakeStep)
            return;
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SetAction(skills, move, 0);
        }
        if (Input.GetKey(KeyCode.D)) move.x = 1;
        if (Input.GetKey(KeyCode.A)) move.x = -1;        
        if (Input.GetKey(KeyCode.W)) move.y = 1;
        if (Input.GetKey(KeyCode.S)) move.y = -1;
        if (move != Vector2Int.zero)
        {
            SetAction(movement.Action, new Vector2Int(move.y, -move.x));
            StepByStepSystem.GoStep();
            lastMove = move;
            move = Vector2Int.zero;
        }
       
    }   
}
