using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepByStepSystem : MonoBehaviour
{
    [SerializeField] float animationSpeed = 2;
    public delegate void StepByStepSystemDelegate();
    public static StepByStepSystemDelegate GoStep;
    public static event StepByStepSystemDelegate OnStep;

    static float stepAnimationIndex = 0;
    /// <summary>
    /// Animation index from 0 to 1
    /// </summary>
    public static float StepAnimationIndex => stepAnimationIndex;
    public static bool IsMakeStep { get; protected set; }

    private void Start()
    {
        GoStep += Step;
    }
    private void OnDestroy()
    {
        GoStep -= Step;
    }
    void Step()
    {        
        StartCoroutine(StepCoroutine());
        OnStep?.Invoke();
    }
    IEnumerator StepCoroutine()
    {
        stepAnimationIndex = 0;
        IsMakeStep = true;
        while (stepAnimationIndex < 1)
        {
            stepAnimationIndex = Mathf.Clamp01(stepAnimationIndex + Time.deltaTime * animationSpeed);            
            yield return null;
        }
        IsMakeStep = false;
    }

}
