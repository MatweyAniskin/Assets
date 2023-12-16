using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : StepListener
{
    [SerializeField] protected Stats stats;
    protected delegate void StepActionDelegate(Vector2Int dir, Stats stats, object[] args = null);
    StepActionDelegate CurAction;
    public delegate void BehaviourActionDelegate();
    public event BehaviourActionDelegate OnBehaviourAction;    
    protected Vector2Int dir;
    
    private object[] args = null;

    protected void SetAction(StepActionDelegate stepAction, Vector2Int dir, object[] args = null)
    {
        CurAction = stepAction;
        this.dir = dir;
        this.args = args;
    }
    protected void SetAction(StepAction stepAction, Vector2Int dir, object[] args = null)
    {
        stepAction.Select(dir,stats,args);
        SetAction(stepAction.Action, dir, args);
    }    
    public override void StepAction()
    {                
        CurAction?.Invoke(dir, stats, args);
        OnBehaviourAction?.Invoke();
    }    
}
