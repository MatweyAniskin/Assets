using System.Collections;
using UnityEngine;

namespace Animation
{
    [CreateAssetMenu(fileName = "PositionDirAnimation", menuName = "CurveAnimation/PositionDirAnimation")]
    public class PositionWithCustomDirAnimation : SpriteAnimationProfile
    {
        [SerializeField] Vector3 staticDirection;
        [SerializeField] AnimationCurve staticCurve;
        [SerializeField] bool inverseDir = false;
        public override IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer)
        {
            Vector3 spriteEndPosition;
            Vector3 customDir = new Vector3(dir.x * (inverseDir ? -1 : 1), 0, dir.y * (inverseDir ? -1 : 1));
            float index;
            while (StepByStepSystem.IsMakeStep)
            {
                index = StepByStepSystem.StepAnimationIndex;
                spriteEndPosition = spriteStartPosition + customDir * curve.Evaluate(index) + staticDirection* staticCurve.Evaluate(index);
                spriteTransform.localPosition = Vector3.Lerp(spriteStartPosition, spriteEndPosition, index);
                yield return null;
            }
            spriteTransform.localPosition = spriteStartPosition;
        }
    }
}
