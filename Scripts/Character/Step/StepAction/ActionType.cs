using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionType", menuName = "Logic/Action/Type")] 
public class ActionType : ScriptableObject
{
    [SerializeField] string title;    

    public static bool operator ==(ActionType lhs, ActionType rhs) => lhs.title == rhs.title;
    public static bool operator !=(ActionType lhs, ActionType rhs) => !(lhs == rhs);
}