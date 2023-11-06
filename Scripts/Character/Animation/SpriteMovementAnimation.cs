using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovementAnimation : MonoBehaviour
{
    [SerializeField] AnimationAssembly[] animationAssemblies;
    [SerializeField] Transform spriteTransform;
    [SerializeField] SpriteRenderer spriteRenderer;
    Vector3 spriteStartPosition;
    Quaternion spriteStartRotation;
    private void Start()
    {
        spriteStartPosition = spriteTransform.localPosition;
        spriteStartRotation = spriteTransform.localRotation;
        foreach (var assembly in animationAssemblies)
        {
            assembly.AddActionEvent(StartAnimation);
        }
    }
    private void OnDestroy()
    {
        foreach (var assembly in animationAssemblies)
        {
            assembly.RemoveActionEvent(StartAnimation);
        }
    }
    void StartAnimation(Vector2Int dir, SpriteAnimationProfile animationProfile)
    {       
        if(gameObject.activeSelf)
            StartCoroutine(animationProfile.Animation(dir,spriteStartPosition, spriteStartRotation,spriteTransform, spriteRenderer));
    }    
}
