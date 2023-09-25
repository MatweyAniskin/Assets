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
    /// Animation index from 1 to 0
    /// </summary>
    public static float StepAnimationIndex => stepAnimationIndex;
    public static bool IsMakeStep => stepAnimationIndex > 0;

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
        OnStep?.Invoke();
        StartCoroutine(StepCoroutine());
    }
    IEnumerator StepCoroutine()
    {
        stepAnimationIndex = 1;
        while (IsMakeStep)
        {
            stepAnimationIndex = Mathf.Clamp01(stepAnimationIndex - Time.deltaTime * animationSpeed);            
            yield return null;
        }
    }

}
