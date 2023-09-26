using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationAssembly
{
    [SerializeField] StepAction action;
    [SerializeField] SpriteAnimationProfile profile;
    public delegate void AssemblyDelegate(Vector2Int dir, SpriteAnimationProfile animationProfile);
    AssemblyDelegate Assembly;
    public void AddActionEvent(AssemblyDelegate assembly)
    {
        Assembly += assembly;
        action.OnAction += StepAnimationStart;
    }
    public void RemoveActionEvent(AssemblyDelegate assembly)
    {
        Assembly -= assembly;
        action.OnAction -= StepAnimationStart;
    }
    public SpriteAnimationProfile AnimationProfile => profile;

    void StepAnimationStart(Vector2Int dir) => Assembly?.Invoke(dir, AnimationProfile);
}
