using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Animation
{
    [System.Serializable]
    public class AnimationAssembly
    {
        [SerializeField] private string name;
        [SerializeField] StepCallBack action;
        [SerializeField] SpriteAnimationProfile[] profiles;
        [SerializeField] AnimationArgument[] arguments;
        public delegate void AssemblyDelegate(Vector2Int dir, SpriteAnimationProfile animationProfile, params object[] args);
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

        void StepAnimationStart(Vector2Int dir, params object[] args)
        {
            if (arguments.Length != args.Length && !Enumerable.SequenceEqual(arguments, args.Cast<AnimationArgument>()))
                return;
            
            foreach(var i in profiles)
                Assembly?.Invoke(dir, i, args);
        }
        public override string ToString() => name;        
    }
}
