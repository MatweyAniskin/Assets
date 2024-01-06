using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepAction : StepCallBack
{

    [SerializeField] ActionType actionType;
   
    public virtual void Action(Vector2Int dir, Stats stats, params object[] args) 
    {
        Callback(dir);
    }
    public virtual void Select(Vector2Int dir, Stats stats, params object[] args) 
    {
        
    }
    public virtual void DeSelect()
    {

    }
    public ActionType ActionType => actionType;
}
