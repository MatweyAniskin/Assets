using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    [CreateAssetMenu(fileName = "MaterialAnimation", menuName = "CurveAnimation/MaterialAnimation")]
    public class SwapMaterialAnimation : SpriteAnimationProfile
    {
        [SerializeField] Material[] materials;
        [SerializeField] Material defaultMaterial;
        public override IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer)
        {
            float index;
            int spriteIndex;            
            int length = materials.Length;
            while (StepByStepSystem.IsMakeStep)
            {
                index = StepByStepSystem.StepAnimationIndex;
                spriteIndex = Convert.ToInt32(Mathf.Lerp(0, length - 1, curve.Evaluate(index)));
                renderer.material = materials[spriteIndex];
                yield return null;
            }
            if(defaultMaterial != null)
                renderer.material = defaultMaterial;
        }
    }
}