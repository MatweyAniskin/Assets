using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] Loader[] loaders;
    public Loader[] Loaders => loaders;
    public override string ToString() => title;    
}
