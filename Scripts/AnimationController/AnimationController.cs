using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    static List<AnimationBehaviour> animationBehaviours = new List<AnimationBehaviour>();
    public static void Add(AnimationBehaviour animationBehaviour) => animationBehaviours.Add(animationBehaviour);
    public static AnimationBehaviour GetBehaviour(int index) => animationBehaviours[index];
    private void Awake()
    {
        animationBehaviours.Clear();
    }
}
