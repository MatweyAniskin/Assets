using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconWithText : IconWithShadow
{
    [SerializeField] Text title;
    [SerializeField] Text description;

    public override void SetElement(IViewElement element)
    {
        title.text = element.Title;
        description.text = element.Description;
        base.SetElement(element);
    }
}
