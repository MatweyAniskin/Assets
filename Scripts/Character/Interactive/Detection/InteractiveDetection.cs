using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveDetection : BehaviourListener
{
    [SerializeField] protected MatrixTransform matrixTransform;
    public override void StepAction()
    {
        MatrixTransform temp = TransformRepository.GetTransformInPosition(matrixTransform);
        if (temp is null)
        {
            NotDetectedInteractive();
            return;
        }
        if (temp is IInteractiveObject) DetectInteractive((IInteractiveObject)temp);
    }
    protected abstract void DetectInteractive(IInteractiveObject interactive);
    protected abstract void NotDetectedInteractive();
}
