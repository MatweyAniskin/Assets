using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : StepListener
{
   
    protected delegate void StepActionDelegate(Vector2Int dir, Stats stats);
    StepActionDelegate CurAction;
    public delegate void BehaviourActionDelegate();
    public event BehaviourActionDelegate OnBehaviourAction;    
    protected Vector2Int dir;
    protected Stats stats;    
    protected void SetAction(StepActionDelegate stepAction, Vector2Int dir)
    {
        CurAction = stepAction;
        this.dir = dir;
    }
    public override void OnStart()
    {
        stats = GetComponent<Stats>();
    }
    public override void StepAction()
    {                
        CurAction?.Invoke(dir, stats);
        OnBehaviourAction?.Invoke();
    }
}
