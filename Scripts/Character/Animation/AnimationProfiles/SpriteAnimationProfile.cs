using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public abstract class SpriteAnimationProfile : ScriptableObject
    {
        [SerializeField] protected AnimationCurve curve;
        public abstract IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform, SpriteRenderer renderer);
    }
}
