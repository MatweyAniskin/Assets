using Animation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class EffectAssembly
{
    [SerializeField] AnimationArgument[] arguments;
    [SerializeField] GameObject[] effects;
    [SerializeField] Vector3 offset;

    public Vector3 Offset => offset;
    public GameObject Effect => effects[Random.Range(0, effects.Length)];

    public static bool operator ==(EffectAssembly a, IEnumerable<AnimationArgument> b) => Enumerable.SequenceEqual(a.arguments,b);
    public static bool operator !=(EffectAssembly a, IEnumerable<AnimationArgument> b) => !(a == b);

}
