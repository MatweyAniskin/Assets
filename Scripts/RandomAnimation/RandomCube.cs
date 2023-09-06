using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomCube
{
    [SerializeField] [Tooltip("Inclusive value")] int minCount = 1;    
    [SerializeField] [Tooltip("Exclusive value")] int maxCount = 7;
    public int Min => minCount;
    public int Max => maxCount;

    public int Random => UnityEngine.Random.Range(Min, Max);
}
