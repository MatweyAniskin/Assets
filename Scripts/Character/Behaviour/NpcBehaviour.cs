using System.Linq;
using UnityEngine;

public class NpcBehaviour : CharacterBehaviour
{
    [SerializeField] StateMachine stateMachine;
    [SerializeField] MatrixTransform matrixTransform;
    StepAction[] stepActions;

    MatrixTransform attackTarget;

    public MatrixTransform AttackTarget => attackTarget;
    public bool IsTargeting => !(attackTarget is null);
    public void SetTarget(MatrixTransform target) => attackTarget = target;
    public override void OnStart()
    {
        stepActions = GetComponents<StepAction>();
        base.OnStart();      
    }
    public override void StepAction()
    {        
        base.StepAction();
        SetAction(GetNextStep(), CalculateDir());
    }
    Vector2Int CalculateDir()
    {
        if (attackTarget is null)
            return new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));
        return MatrixTransform.CalculateDirection(matrixTransform, AttackTarget);
    }
    StepActionDelegate GetNextStep()
    {
        ActionType.Types type = stateMachine.NextAction();
        StepAction[] tempActions = stepActions.Where(i => i.ActionType == type).ToArray();
        if (tempActions.Length > 0)
            return GetActionInArray(tempActions);
        return GetActionInArray(stepActions);
    }
    StepActionDelegate GetActionInArray(StepAction[] tempActions) => tempActions[Random.Range(0, tempActions.Length)].Action;
}
