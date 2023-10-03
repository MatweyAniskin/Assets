using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveUiController : MonoBehaviour
{
    [SerializeField] InteractiveObjectIcon prefabIconInteractiveElement;
    InteractiveObjectIcon curIcon;
    void Start()
    {
        PlayerInteractiveDetection.OnDetection += DetectedSet;
        PlayerInteractiveDetection.OnNotDetected += Clear;
    }
    private void OnDestroy()
    {
        PlayerInteractiveDetection.OnDetection -= DetectedSet;
        PlayerInteractiveDetection.OnNotDetected -= Clear;
    }
    void Clear()
    {
        if (curIcon != null)
        {
            curIcon.Destroy();
            curIcon = null;
        }
    }
    void DetectedSet(IInteractiveObject interactiveObject)
    {
        Clear();
        if (interactiveObject is null)                   
            return;
        curIcon = Instantiate(prefabIconInteractiveElement,transform) as InteractiveObjectIcon;
        curIcon.SetElement(interactiveObject);        
    }
}
