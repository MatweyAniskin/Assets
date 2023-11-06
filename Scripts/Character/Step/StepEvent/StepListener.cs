using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepListener : MonoBehaviour
{
    private void Start()
    {
        
        OnStart();
    }
    private void OnDestroy()
    {        
        OnDelete();
    }
    private void OnEnable()
    {
        StepByStepSystem.OnStep += StepAction;
        OnActiveObject();
    }
    private void OnDisable()
    {
        StepByStepSystem.OnStep -= StepAction;
    }
    public virtual void OnActiveObject() { }
    public virtual void OnStart() { }
    public virtual void OnDelete() { }
    public abstract void StepAction();
}
