using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] ActionType[] actions;
    public abstract bool Rule(Stats stats, NpcBehaviour behaviour);
    public ActionType[] Script => actions;
    public override string ToString() => title;    
}
