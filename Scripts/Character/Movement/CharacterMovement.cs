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
        nextPosition = CheckState(out int curStep, dir);
        matrixTransform.LogicPosition = nextPosition;
        Vector3 endPosition = MatrixTransform.MatrixToPosition(nextPosition,transform.position);        
        base.Action(dir, stats);
        StartCoroutine(AnimationCoroutine(transform.position, endPosition));
    }
    Vector2Int CheckState(out int curStepBlocks,Vector2Int dir)
    {
        Vector2Int res = matrixTransform.Position;
        Vector2Int cur;
        for (curStepBlocks = 0; curStepBlocks <= stepBlocks; curStepBlocks++)
        {
            cur = matrixTransform.Position + dir * curStepBlocks;
            if (MovementMatrix.CheckState(cur, matrixTransform.Radius))
            {
                res = cur;
            }else
            {
                break;
            }
        }
        return res;
    }
   
    IEnumerator AnimationCoroutine(Vector3 startPosition,Vector3 endPosition)
    {       
        while (StepByStepSystem.IsMakeStep)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, animation.Evaluate(StepByStepSystem.StepAnimationIndex));           
            yield return null;
        }
        matrixTransform.RecalculateMatrixPositionToUnitPosition();        
    }
}
