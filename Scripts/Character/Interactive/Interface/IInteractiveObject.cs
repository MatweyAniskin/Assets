using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractiveObject : IViewElement
{
    public delegate void DragDelegate();
    public event DragDelegate OnDetectorEnter;
    public event DragDelegate OnDetectorExit;
    public void OnEnter();
    public void OnExit();
    public void UseObject(MatrixTransform user);
    public Vector3 Position { get;}
}
