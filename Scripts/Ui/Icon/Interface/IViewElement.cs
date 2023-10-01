using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IViewElement
{
    public Sprite Icon { get; }
    public string Description { get; }
    public string Title { get; }
}
