using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepAction : MonoBehaviour
{
    [SerializeField] ActionType.Types actionType;
    public abstract void Action(Vector2Int dir, Stats stats);
}
