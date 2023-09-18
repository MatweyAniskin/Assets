using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ScriptableAnimation[] scriptableAnimation;
    [Tooltip("Seconds between animation frame")][SerializeField] float secondPerFrame = 0.1f;
    [Tooltip("Current animation index")][SerializeField] int curAnimation = 0;

    float secondBetweenFrames = 0;    
    public bool FlipSprite
    {
        set => transform.rotation = Quaternion.Euler(0,value? 180 : 0,0);
        //get => animator.flipX;
    }
    public void SetAnimation(string name, bool value) => animator.SetBool(name, value);
}
