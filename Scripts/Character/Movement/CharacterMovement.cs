using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : StepAction
{
    [SerializeField] float moveLength;
    [SerializeField] AnimationCurve animation;
    [SerializeField] Transform sprite;
    [SerializeField] AnimationCurve spriteAnimation; //unit
    public override void Action(Vector2Int dir, Stats stats)
    {
        Vector3 endPosition = transform.position + new Vector3(dir.x, 0, dir.y)* moveLength;
        StartCoroutine(AnimationCoroutine(transform.position, endPosition));
    }    
    IEnumerator AnimationCoroutine(Vector3 startPosition,Vector3 endPosition)
    {
        Vector3 spriteStartPosition = sprite.localPosition;
        Vector3 spriteEndPosition;
        while (StepByStepSystem.IsMakeStep)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, animation.Evaluate(StepByStepSystem.StepAnimationIndex));
            spriteEndPosition = spriteStartPosition + Vector3.up * spriteAnimation.Evaluate(StepByStepSystem.StepAnimationIndex);
            sprite.localPosition = Vector3.Lerp(spriteStartPosition, spriteEndPosition, StepByStepSystem.StepAnimationIndex);
            yield return null;
        }
        sprite.localPosition = spriteStartPosition;
    }
}
