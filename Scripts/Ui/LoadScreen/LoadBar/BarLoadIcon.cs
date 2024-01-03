using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLoadIcon : Icon
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] Vector2 dir = Vector2.up;
    [SerializeField] float animationTime = 1f;
    [SerializeField] Gradient gradient;

    private Vector2 defaultPosition;
    public void SetIconBar(Sprite sprite, Vector2 position)
    {
        SetIcon(sprite);
        SetPosition(defaultPosition = position);
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
    {        
        float index = 0;        
        for (float t = 0; t <= animationTime; t += Time.deltaTime)
        {
            index = t / animationTime;
            Position = defaultPosition + dir * curve.Evaluate(index);
            IconColor = gradient.Evaluate(index);
            yield return null;
        }
    }
}
