using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : StepListener
{
    [SerializeField] protected Stats stats;    
    StepAction curStepAction;    
    public delegate void BehaviourActionDelegate();
    public event BehaviourActionDelegate OnBehaviourAction;
    protected Vector2Int dir;
    
    private object[] args = null;
    
    protected void SetAction(StepAction stepAction, Vector2Int dir, params object[] args)
    {
        curStepAction?.DeSelect();
        
        curStepAction = stepAction;
        this.dir = dir;
        this.args = args;
        curStepAction?.Select(dir,stats,args);        
    }    
    public override void StepAction()
    {
        curStepAction?.Action(dir, stats, args);
        OnBehaviourAction?.Invoke();
    }    
}
