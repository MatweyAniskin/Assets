using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Logic/Input/KeyProfile")]
public class KeyProfile : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] KeyCode key;
    [SerializeField] KeyCode altKey;
    protected delegate bool IsKeyDelegate(KeyCode keyCode);
    public bool CheckKeyDown() => IsKey(Input.GetKeyDown);
    public bool CheckKeyUp() => IsKey(Input.GetKeyUp);
    bool IsKey(IsKeyDelegate method) => method(this.key) || method(altKey);
}
