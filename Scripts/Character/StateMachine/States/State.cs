using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] ActionType.Types[] actions;
    public abstract bool Rule(Stats stats, NpcBehaviour behaviour);
    public ActionType.Types[] Script => actions;
    public override string ToString() => title;    
}
