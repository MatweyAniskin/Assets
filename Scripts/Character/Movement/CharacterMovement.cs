using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : StepAction
{
    [SerializeField] AnimationCurve animation;
    [SerializeField] Vector2Int matrixPosition; //unit
    [SerializeField] int radius = 1;
    [SerializeField] int stepBlocks = 2;
    float blockScale;
    private void Start()
    {
        blockScale = GenerateProperty.BlockScale;
        matrixPosition = new Vector2Int(Mathf.CeilToInt(transform.position.x / blockScale), Mathf.CeilToInt(transform.position.z / blockScale));
        transform.position = MatrixToPosition();
    }

    public override void Action(Vector2Int dir, Stats stats)
    {                        
            matrixPosition = CheckState(out int curStep, dir);
        Vector3 endPosition = MatrixToPosition();        
        ActionEvent(dir);
        StartCoroutine(AnimationCoroutine(transform.position, endPosition));
    }
    Vector2Int CheckState(out int curStepBlocks,Vector2Int dir)
    {
        Vector2Int res = matrixPosition;
        Vector2Int cur;
        for (curStepBlocks = 0; curStepBlocks <= stepBlocks; curStepBlocks++)
        {
            cur = matrixPosition + dir * curStepBlocks;
            if (MovementMatrix.CheckState(cur, radius))
            {
                res = cur;
            }else
            {
                break;
            }
        }
        return res;
    }
    Vector3 MatrixToPosition() => MatrixToPosition(matrixPosition);
    Vector3 MatrixToPosition(Vector2Int pos) => new Vector3(pos.x * blockScale, transform.position.y, pos.y * blockScale);
    IEnumerator AnimationCoroutine(Vector3 startPosition,Vector3 endPosition)
    {       
        while (StepByStepSystem.IsMakeStep)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, animation.Evaluate(StepByStepSystem.StepAnimationIndex));           
            yield return null;
        }        
    }
}
