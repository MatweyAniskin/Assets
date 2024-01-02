using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    [CreateAssetMenu(fileName = "PositionAnimation", menuName = "CurveAnimation/PositionAnimation")]
    public class PositionSpriteAnimation : SpriteAnimationProfile
    {
        [SerializeField] Vector3 animationDirection;
        /// <summary>
        /// AnimationCaroutine
        /// </summary>
        /// <param name="dir">Animation direction</param>
        /// <param name="spriteStartPosition">Sprite Renderer default position</param>
        /// <param name="startRotation">Sprite Renderer default rotation</param>
        /// <param name="spriteTransform">Sprite Renderer transform (or mother object)</param>
        /// <param name="renderer">Main Sprite Renderer</param>
        /// <returns></returns>
        public override IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer)
        {
            Vector3 spriteEndPosition;
            float index;
            while (StepByStepSystem.IsMakeStep)
            {
                index = StepByStepSystem.StepAnimationIndex;
                spriteEndPosition = spriteStartPosition + animationDirection * curve.Evaluate(index);
                spriteTransform.localPosition = Vector3.Lerp(spriteStartPosition, spriteEndPosition, index);
                yield return null;
            }
            spriteTransform.localPosition = spriteStartPosition;
        }
    }
}
