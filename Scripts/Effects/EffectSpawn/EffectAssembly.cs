using Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectAssembly
{
    [SerializeField] AnimationArgument argument;
    [SerializeField] GameObject[] effects;

    public GameObject Effect => effects[Random.Range(0, effects.Length)];

    public static bool operator ==(EffectAssembly a, AnimationArgument b) => a.argument == b;
    public static bool operator !=(EffectAssembly a, AnimationArgument b) => !(a == b);

}
