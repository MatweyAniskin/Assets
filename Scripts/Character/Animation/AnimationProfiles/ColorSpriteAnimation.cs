using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    [CreateAssetMenu(fileName = "ColorAnimation", menuName = "CurveAnimation/ColorSpriteAnimation")]
    public class ColorSpriteAnimation : SpriteAnimationProfile
    {
        [SerializeField] Gradient gradient;
        public override IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer)
        {
            float index;            
            while (StepByStepSystem.IsMakeStep)
            {
                index = StepByStepSystem.StepAnimationIndex;
                renderer.color = gradient.Evaluate(curve.Evaluate(index));
                yield return null;
            }            
        }
    }
}
