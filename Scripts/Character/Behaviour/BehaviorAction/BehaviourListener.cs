using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourListener : MonoBehaviour
{
    [SerializeField] protected CharacterBehaviour characterBehaviour;
    private void Start()
    {
        characterBehaviour.OnBehaviourAction += StepAction;
        OnStart();
    }
    private void OnDestroy()
    {
        characterBehaviour.OnBehaviourAction -= StepAction;
        OnDelete();
    }
    public virtual void OnStart() { }
    public virtual void OnDelete() { }
    public abstract void StepAction();
}
