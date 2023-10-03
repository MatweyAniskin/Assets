using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepAction : MonoBehaviour
{

    [SerializeField] ActionType.Types actionType;
    public delegate void StepActionDelegate(Vector2Int dir);
    public event StepActionDelegate OnAction;
    public abstract void Action(Vector2Int dir, Stats stats);
    protected void ActionEvent(Vector2Int dir) => OnAction?.Invoke(dir);
    
}
