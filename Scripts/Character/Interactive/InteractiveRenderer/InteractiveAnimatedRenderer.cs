using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAnimatedRenderer : InteractiveRenderer
{    
    [SerializeField] SpriteAnimationProfile[] enterAnimations;
    [SerializeField] SpriteAnimationProfile[] exitAnimations;
    Transform spriteRendererTransform;
    Quaternion startRotation;
    Vector3 startPosition;
    protected override void OnStart()
    {
        spriteRendererTransform = spriteRenderer.transform;
        startRotation = spriteRendererTransform.localRotation;
        startPosition = spriteRendererTransform.localPosition;
    }
    protected override void OnEnter()
    {
        StartAnimations(enterAnimations);
        base.OnEnter();
    }
    protected override void OnExit()
    {
        StartAnimations(exitAnimations);
        base.OnExit();
    }    
    void StartAnimations(SpriteAnimationProfile[] profiles)
    {
        foreach (var animation in profiles)
        {
           StartCoroutine(animation.Animation(Vector2Int.zero, startPosition, startRotation, spriteRendererTransform, spriteRenderer));
        }
    }
}
