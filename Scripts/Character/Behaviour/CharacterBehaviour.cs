using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
   
    protected delegate void StepActionDelegate(Vector2Int dir, Stats stats);
    StepActionDelegate CurAction;
    protected Vector2Int dir;
    protected Stats stats;
    private void Start()
    {
        StepByStepSystem.OnStep += StepAction;       
        stats = GetComponent<Stats>();
        OnStart();
    }
    private void OnDestroy()
    {
        StepByStepSystem.OnStep -= StepAction;
        OnDelete();
    }
    protected void SetAction(StepActionDelegate stepAction, Vector2Int dir)
    {
        CurAction = stepAction;
        this.dir = dir;        
    }
    public abstract void OnStart();
    public abstract void OnDelete();
    void StepAction() => CurAction?.Invoke(dir, stats);
}
