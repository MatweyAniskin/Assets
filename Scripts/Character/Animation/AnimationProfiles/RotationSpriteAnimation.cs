using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotationAnimation", menuName = "CurveAnimation/RotationAnimation")]
public class RotationSpriteAnimation : SpriteAnimationProfile
{
    [SerializeField] float multiplyer;
    public override IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer)
    {
        Quaternion spriteEndRotation;
        float index;
        while (StepByStepSystem.IsMakeStep)
        {
            index = StepByStepSystem.StepAnimationIndex;
            spriteEndRotation = Quaternion.Euler(0,0, curve.Evaluate(index) * multiplyer);
            spriteTransform.localRotation = Quaternion.Lerp(startRotation, spriteEndRotation, index);
            yield return null;
        }
        spriteTransform.localRotation = startRotation;
    }
}
