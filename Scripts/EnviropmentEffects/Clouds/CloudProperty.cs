using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CloudProperty
{
    [SerializeField] float min;
    [SerializeField] float max;

    public float Min => min;
    public float Max => max;
    public float Random => UnityEngine.Random.Range(Min, Max);
}
