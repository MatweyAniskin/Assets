using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject, IViewElement
{
    [SerializeField] string keyName;
    [SerializeField] string description;
    [SerializeField] Sprite icon;
    [SerializeField] float weight;
    public Sprite Icon => icon;
    public float Weight => weight;
    public virtual string Description => description;
    public virtual string Title => keyName;
    public static bool operator ==(Item a, string b) => a.keyName == b;
    public static bool operator !=(Item a, string b) => a.keyName != b;
    public override string ToString() => Title;
}
