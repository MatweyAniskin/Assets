using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepAction : MonoBehaviour
{

    [SerializeField] ActionType actionType;
    public delegate void StepActionDelegate(Vector2Int dir);
    public event StepActionDelegate OnAction;
    public virtual void Action(Vector2Int dir, Stats stats, object[] args = null) 
    {
        OnAction?.Invoke(dir);
    }
    public virtual void Select(Vector2Int dir, Stats stats, object[] args = null) { }
    public ActionType ActionType => actionType;
}
