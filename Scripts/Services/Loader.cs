using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Loader : MonoBehaviour
{
    [SerializeField] int order;
    [SerializeField] string loaderName;
    public int Order  => order;
    public string Name => loaderName;
    public abstract void StartWork();
    public abstract bool Next();
}
