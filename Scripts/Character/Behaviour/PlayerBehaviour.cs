using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    [SerializeField] StepAction movement;
    [SerializeField] StepAction skills;
    Vector2Int move;
    Vector2Int lastMove = Vector2Int.up;
    int skillButton = -1;
    int lastSkillButton = -1;
    public enum Type { IsMove = 0, IsSkills = 1 }
    Type CurActionType 
    {
        get => curActionType;
        set
        {
            curActionType = value;
            OnChangeActionType?.Invoke(curActionType);
        }
    }
    Type curActionType;
    delegate void ActionDelegate();    
    ActionDelegate[] actionDelegates;
    delegate bool KeyDelegate(KeyCode keyCode);
    public delegate void TypeDelegate(Type type);
    public static event TypeDelegate OnChangeActionType;
    private void Start()
    {
        actionDelegates = new ActionDelegate[] { Move, Skills};
    }
    private void Update()//Unit test REWRITE ALL THIS SHIT
    {
        if (StepByStepSystem.IsMakeStep)
            return;
        actionDelegates[(int)CurActionType].Invoke();
        SetType();
    }
    void SetType()
    {
        skillButton = SkillIndex();       
        switch(CurActionType)
        {
            case Type.IsMove:
                if(skillButton != -1)
                {
                    CurActionType = Type.IsSkills;
                    SetAction(skills, lastMove, skillButton);
                    lastSkillButton = skillButton;
                }
                return;
            case Type.IsSkills:
                if (skillButton == lastSkillButton)
                {
                    StepByStepSystem.GoStep();
                    SetAction(movement, move);
                    CurActionType = Type.IsMove;
                    return;
                }
                if (skillButton != -1)
                    lastSkillButton = skillButton;
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    SetAction(movement, move);
                    CurActionType = Type.IsMove;
                }
                return;
        }
    }
    void Move()
    {
        move = MoveAxis();
        if (move != Vector2Int.zero)
        {
            SetAction(movement, move);            
            lastMove = move;
            move = Vector2Int.zero;
            StepByStepSystem.GoStep();
        }
    }
    void Skills()
    {
        var temp = MoveDirection();
        if (temp != Vector2Int.zero)
        {
            move = new Vector2Int(Mathf.Clamp(move.x + temp.x,-1,1), Mathf.Clamp(move.y + temp.y,-1,1));
            if (move == Vector2Int.zero) move = temp;
            lastMove = move;
            SetAction(skills, move, lastSkillButton);
        }        
    }
    Vector2Int MoveAxis() => MoveDir(Input.GetKey);
    Vector2Int MoveDirection() => MoveDir(Input.GetKeyUp);
    Vector2Int MoveDir(KeyDelegate keyDelegate)
    {
        Vector2Int move = Vector2Int.zero;
        if (keyDelegate(KeyCode.D)) move.y = -1;
        if (keyDelegate(KeyCode.A)) move.y = 1;
        if (keyDelegate(KeyCode.W)) move.x = 1;
        if (keyDelegate(KeyCode.S)) move.x = -1;
        return move;
    }
    int SkillIndex()
    {
        int index = -1;
        if (Input.GetKeyUp(KeyCode.Alpha1)) index = 0;
        return index;
    }
}
