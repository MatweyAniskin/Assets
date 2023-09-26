using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : StepAction
{
    [SerializeField] float moveLength;
    [SerializeField] AnimationCurve animation;    

  

    public override void Action(Vector2Int dir, Stats stats)
    {
        Vector3 endPosition = transform.position + new Vector3(dir.x, 0, dir.y)* moveLength;
        ActionEvent(dir);
        StartCoroutine(AnimationCoroutine(transform.position, endPosition));
    }    
    IEnumerator AnimationCoroutine(Vector3 startPosition,Vector3 endPosition)
    {       
        while (StepByStepSystem.IsMakeStep)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, animation.Evaluate(StepByStepSystem.StepAnimationIndex));           
            yield return null;
        }        
    }
}
