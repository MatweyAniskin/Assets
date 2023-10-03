using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IInteractiveObject))]
public class InteractiveRenderer : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected int standartOrder = 1;
    [SerializeField] protected int viewOrder = 10;
    IInteractiveObject interactiveObject;
    
    void Start()
    {        
        interactiveObject = GetComponent<IInteractiveObject>();
        interactiveObject.OnDetectorEnter += OnEnter;
        interactiveObject.OnDetectorExit += OnExit;
        OnStart();
    }

    private void OnDestroy()
    {
        interactiveObject.OnDetectorEnter -= OnEnter;
        interactiveObject.OnDetectorExit -= OnExit;
    }
    protected virtual void OnStart() { }
    protected virtual void OnEnter() => spriteRenderer.sortingOrder = viewOrder;
    protected virtual void OnExit() => spriteRenderer.sortingOrder = standartOrder;
}
