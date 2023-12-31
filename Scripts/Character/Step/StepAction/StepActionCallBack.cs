using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepActionCallBack : MonoBehaviour
{
    public delegate void StepActionDelegate(Vector2Int dir, params object[] args);
    public event StepActionDelegate OnAction;

    public virtual void Callback(Vector2Int dir, params object[] args) => OnAction?.Invoke(dir, args);
}
