using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : StepAction
{
    [SerializeField] protected MatrixTransform matrixTransform;
    [SerializeField] AnimationCurve animation;    
    [SerializeField] protected int stepBlocks = 2;    
    Vector2Int nextPosition;   

    public override void Action(Vector2Int dir, Stats stats)
    {
        nextPosition = MovementMatrix.MoveMatrixToNextPosition(dir,stepBlocks,matrixTransform);
        matrixTransform.LogicPosition = nextPosition;
        Vector3 endPosition = MatrixTransform.MatrixToPosition(nextPosition,transform.position);        
        base.Action(dir, stats);        
            StartCoroutine(AnimationCoroutine(transform.position, endPosition));
    }   
   
    IEnumerator AnimationCoroutine(Vector3 startPosition,Vector3 endPosition)
    {       
        while (StepByStepSystem.IsMakeStep && gameObject.activeSelf)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, animation.Evaluate(StepByStepSystem.StepAnimationIndex));           
            yield return null;
        }
        matrixTransform.RecalculateMatrixPositionToUnitPosition();        
    }
}
