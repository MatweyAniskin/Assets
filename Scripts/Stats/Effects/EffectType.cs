using UnityEngine;

public abstract class EffectType : ScriptableObject
{
    [SerializeField] Sprite icon;
    [SerializeField] string keyName;
    public Sprite Icon => icon;
    public virtual float ValueCalculate(float value) => value;
    public virtual string ValueLine(float value) => value.ToString();
    public override string ToString() => keyName;
}
