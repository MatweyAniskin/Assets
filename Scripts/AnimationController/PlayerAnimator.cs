using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : AnimationController
{
    /*[SerializeField] MoveCharacter moveController;
    Vector2 dir;
    private void Start()
    {
        if (moveController == null)
            return;
        moveController.OnMove += MoveAnimation;
        moveController.OnStop += IdleAnimation;
        moveController.OnFallStart += FallStart;
        moveController.OnFallEnd += FallEnd;
    }
    private void OnDestroy()
    {
        if (moveController == null)
            return;
        moveController.OnMove -= MoveAnimation;
        moveController.OnStop -= IdleAnimation;
        moveController.OnFallStart -= FallStart;
        moveController.OnFallEnd -= FallEnd;
    }
    private void Update()
    {
        if ((dir = moveController.MoveMagnitude) != Vector2.zero)
        {
            FlipSprite = dir.x < 0;
        }
        SetAnimation("Move", moveController.MoveMagnitude.x != 0);
    }

    void FallStart()
    {
        SetAnimation("Fall", true);
    }
    void FallEnd()
    {
        SetAnimation("Fall", false);
    }
    void MoveAnimation(Vector2 dir)
    {
        FlipSprite = dir.x < 0;
        SetAnimation("Move", true);
    }
    void IdleAnimation()
    {
        SetAnimation("Move", false);
    }*/
}
