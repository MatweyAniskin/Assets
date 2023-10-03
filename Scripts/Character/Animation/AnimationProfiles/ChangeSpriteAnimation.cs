using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ChangeSpriteAnimation", menuName = "CurveAnimation/ChangeSpriteAnimation")]
public class ChangeSpriteAnimation : SpriteAnimationProfile
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] [Tooltip("Where animation end set sprite, -1 is not set")]int forceSetSprite = -1;
    public override IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer)
    { 
        float index;
        int spriteIndex;
        int length = sprites.Length;
        while (StepByStepSystem.IsMakeStep)
        {
            index = StepByStepSystem.StepAnimationIndex;
            spriteIndex = Convert.ToInt32(Mathf.Lerp(0, length-1, curve.Evaluate(index)));
            renderer.sprite = sprites[spriteIndex];
            yield return null;
        }
        if (forceSetSprite >= 0)
            renderer.sprite = sprites[forceSetSprite];
    }
}
