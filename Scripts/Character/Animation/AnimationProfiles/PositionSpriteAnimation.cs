using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PositionAnimation", menuName = "CurveAnimation/PositionAnimation")]
public class PositionSpriteAnimation : SpriteAnimationProfile
{  
    [SerializeField] Vector3 animationDirection;
    public override IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer)
    {
        Vector3 spriteEndPosition;
        float index;
        while (StepByStepSystem.IsMakeStep )
        {
            index = StepByStepSystem.StepAnimationIndex;
            spriteEndPosition = spriteStartPosition + animationDirection * curve.Evaluate(index);
            spriteTransform.localPosition = Vector3.Lerp(spriteStartPosition, spriteEndPosition, index);
            yield return null;
        }
        spriteTransform.localPosition = spriteStartPosition;
    }
}
