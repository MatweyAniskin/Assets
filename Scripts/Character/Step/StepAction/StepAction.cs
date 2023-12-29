using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepAction : MonoBehaviour
{

    [SerializeField] ActionType actionType;
    public delegate void StepActionDelegate(Vector2Int dir);
    public event StepActionDelegate OnAction;
    public virtual void Action(Vector2Int dir, Stats stats, params object[] args) 
    {
        OnAction?.Invoke(dir);
    }
    public virtual void Select(Vector2Int dir, Stats stats, params object[] args) 
    {
        
    }
    public virtual void DeSelect()
    {

    }
    public ActionType ActionType => actionType;
}
