using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconWithTitle : IconWithShadow
{
    [SerializeField] Text title;  

    public override void SetElement(IViewElement element)
    {
        title.text = element.Title;       
        base.SetElement(element);
    }
}
