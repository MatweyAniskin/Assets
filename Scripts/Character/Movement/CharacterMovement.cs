using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : StepAction
{
    [SerializeField] MatrixTransform matrixTransform;
    [SerializeField] AnimationCurve animation;    
    [SerializeField] int stepBlocks = 2;
    float blockScale;
    Vector2Int nextPosition;
    private void Start()
    {
        blockScale = GenerateProperty.BlockScale;
        matrixTransform.Position = matrixTransform.PositionToMatrix();      
    }

    public override void Action(Vector2Int dir, Stats stats)
    {
        nextPosition = CheckState(out int curStep, dir);
        Vector3 endPosition = MatrixTransform.MatrixToPosition(nextPosition,transform.position);        
        ActionEvent(dir);
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
        matrixTransform.Position = nextPosition;
    }
}
