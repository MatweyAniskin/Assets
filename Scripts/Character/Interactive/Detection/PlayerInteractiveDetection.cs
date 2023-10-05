using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractiveDetection : InteractiveDetection
{    
    public delegate void InteractiveDetectionDelegate(IInteractiveObject interactive);
    public static event InteractiveDetectionDelegate OnDetection;
    public delegate void InteractiveNotDetectionDelegate();
    public static event InteractiveNotDetectionDelegate OnNotDetected;

    IInteractiveObject curInteractive;

    private void Update() //Unit
    {
        if (StepByStepSystem.IsMakeStep)
            return;
        if (Input.GetKeyDown(KeyCode.E)) UseInteractive();
    }
    void UseInteractive()
    {
        if (curInteractive is null)
            return;
        curInteractive.UseObject(matrixTransform);
        OnNotDetected?.Invoke();
    }
    protected override void DetectInteractive(IInteractiveObject interactive)
    {
        CallExitInteractiveObject();
        interactive.OnEnter();
        curInteractive = interactive;
        OnDetection?.Invoke(interactive);
    }

    protected override void NotDetectedInteractive()
    {
        CallExitInteractiveObject();
        curInteractive = null;
        OnNotDetected?.Invoke();
    }
    void CallExitInteractiveObject()
    {
        if(curInteractive is null) return;
        curInteractive.OnExit();
    }
}
