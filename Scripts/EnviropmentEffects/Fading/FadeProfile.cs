using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FadeProfile")]
public class FadeProfile : ScriptableObject
{
    [SerializeField] Gradient fadeColor;    
    [SerializeField] float maxFadeDistance = 50;

    public Color GetFadeColor(float distance) => fadeColor.Evaluate(Mathf.Clamp01(distance/maxFadeDistance));
}
