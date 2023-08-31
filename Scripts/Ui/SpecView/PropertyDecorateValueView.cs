using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyDecorateValueView : PropertyView
{
    public override void SetProperty(PropertyValue effectValue)
    {
        SetIcon(effectValue.Icon);
        valueText.text = effectValue.EffectType.ValueLine(effectValue.Value);
    }
}
