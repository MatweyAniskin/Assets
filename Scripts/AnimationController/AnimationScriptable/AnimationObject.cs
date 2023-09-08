using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationObject : ScriptableObject
{    
    public bool IsAnimated { get; protected set; }
    public abstract bool StartAnimation(MonoBehaviour behaviour, AnimationBehaviour animationBehaviour);
    protected abstract IEnumerator Animation();
}
