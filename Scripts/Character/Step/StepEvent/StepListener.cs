using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepListener : MonoBehaviour
{
    private void Start()
    {
        StepByStepSystem.OnStep += StepAction;     
        OnStart();
    }
    private void OnDestroy()
    {
        StepByStepSystem.OnStep -= StepAction;
        OnDelete();
    }
    public virtual void OnStart() { }
    public virtual void OnDelete() { }
    public abstract void StepAction();
}
