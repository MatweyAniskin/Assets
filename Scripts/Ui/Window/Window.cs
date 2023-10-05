using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] CanvasGroup group;   
    [SerializeField] float windowSpeed = 4f;
    [SerializeField] MovingUiElement[] movingUiElements;
    public delegate void ChangeViewPosition(Transform transform);
    public static event ChangeViewPosition OnChangeViewPoint;

    private static Transform viewPoint = null;
    public static Transform ViewPoint
    {
        set
        {
            if (ViewPoint == value)
                return;
            viewPoint = value;
            OnChangeViewPoint?.Invoke(viewPoint);
        }
        get => viewPoint;
    }    
    protected bool isOpen;

    protected virtual void OnOpen() { }
    protected virtual void OnClose() { }
    public void Open()
    {
        StartCoroutine(OpenAnimation());
        OnOpen();
    }
    public void Close()
    {
        StartCoroutine(CloseAnimation());
        OnClose();
    }
    IEnumerator OpenAnimation()
    {
        StopCoroutine(CloseAnimation());
        isOpen = true;
        group.gameObject.SetActive(true);
        group.alpha = 0;
        foreach (MovingUiElement i in movingUiElements)
            i.StartAnimation(this);
        while (group.alpha != 1)
        {
            group.alpha += Time.unscaledDeltaTime * windowSpeed;
            yield return null;
        }
             
        WindowController.IsOpened = isOpen;
    }
    IEnumerator CloseAnimation()
    {
        StopCoroutine(OpenAnimation());
        ViewPoint = null;
        group.alpha = 1;
        isOpen = false;
        WindowController.IsOpened = isOpen;
        foreach (MovingUiElement i in movingUiElements)
            i.EndAnimation(this);
        while (group.alpha != 0)
        {
            group.alpha -= Time.unscaledDeltaTime * windowSpeed;
            yield return null;
        }

        group.gameObject.SetActive(false);
        
        yield return null;
    }
}
