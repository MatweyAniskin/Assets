using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyFullView : PropertyView
{    
    public override void SetProperty(PropertyValue effectValue)
    {
        SetIcon(effectValue.Icon);
        valueText.text = $"{effectValue}: {effectValue.Value}";
    }
}
