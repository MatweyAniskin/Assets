using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Animation
{
    [CreateAssetMenu(fileName = "Argument", menuName = "CurveAnimation/ArgumentAnimation")]
    public class AnimationArgument : ScriptableObject
    {
        [SerializeField] string argument;
        public override string ToString() => argument;

        public static bool operator ==(AnimationArgument a, string b) => a.argument == b;
        public static bool operator !=(AnimationArgument a, string b) => !(a == b);
    }
}
