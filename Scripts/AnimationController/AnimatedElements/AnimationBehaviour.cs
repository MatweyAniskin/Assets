using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    [SerializeField] AnimationElement[] animationElements;
    private void Start()
    {
        animationElements = this.GetComponents<AnimationElement>();
        AnimationController.Add(this);
    }
    public T GetAnimationElement<T>() where T : AnimationElement => (T)animationElements.FirstOrDefault(i => i.GetType() == typeof(T));
    public static bool operator ==(AnimationBehaviour a, GameObject b) => a.gameObject == b;
    public static bool operator !=(AnimationBehaviour a, GameObject b) => a.gameObject != b;
}
