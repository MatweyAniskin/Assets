using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ActionType;

public class StateMachine : MonoBehaviour
{
    [SerializeField] NpcBehaviour behaviour;
    [SerializeField] Stats stats;    
    [SerializeField] State[] states;

    Queue<ActionType> script = new Queue<ActionType>();
    private void Start()
    {
        NextScript();
    }
    public ActionType NextAction()
    {
        ActionType type = script.Dequeue();
        if (script.Count == 0)
            NextScript();
        return type;
    }
    void NextScript()
    {
        State[] tempStates = states.Where(i => i.Rule(stats,behaviour)).ToArray();
        if (tempStates.Length > 0)
            SetScript(tempStates);
        else 
            SetScript(states);
    }
    void SetScript(State[] curStates) => script = new Queue<ActionType>(curStates[Random.Range(0, curStates.Length)].Script);
}
