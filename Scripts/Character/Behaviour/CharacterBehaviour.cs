using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    StepAction[] stepActions;
    protected delegate void StepActionDelegate(Vector2Int dir, Stats stats);
    protected StepActionDelegate CurAction;
    protected Vector2Int dir;
    protected Stats stats;
    private void Start()
    {
        StepByStepSystem.OnStep += StepAction;
        stepActions = GetComponents<StepAction>();
        stats = GetComponent<Stats>();
        OnStart();
    }
    private void OnDestroy()
    {
        StepByStepSystem.OnStep -= StepAction;
        OnDelete();
    }
    public abstract void OnStart();
    public abstract void OnDelete();
    void StepAction() => CurAction?.Invoke(dir, stats);
}
