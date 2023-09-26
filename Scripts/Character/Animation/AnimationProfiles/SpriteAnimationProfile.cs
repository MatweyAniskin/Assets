using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpriteAnimationProfile : ScriptableObject
{
    public abstract IEnumerator Animation(Vector2Int dir, Vector3 spriteStartPosition, Quaternion startRotation, Transform spriteTransform);    
}
