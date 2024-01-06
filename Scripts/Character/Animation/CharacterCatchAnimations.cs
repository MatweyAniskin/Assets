using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;
using System;

public class CharacterCatchAnimations : StepCallBack
{
    [SerializeField] Stats stats;
    [SerializeField] AnimationArgument[] damageArguments;
    [SerializeField] AnimationArgument[] deadArguments;
    private void Start()
    {
        //stats.OnDamage += OnDamage;
    }
    private void OnDestroy()
    {
        //stats.OnDamage -= OnDamage;
    }

    private void OnDamage(Vector2Int dir, float percent, DamageType damage) => Callback(dir, damageArguments);
}
