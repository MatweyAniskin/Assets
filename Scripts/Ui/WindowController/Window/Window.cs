using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] CanvasGroup group;   
    [SerializeField] float windowSpeed = 4f;
    [SerializeField] MovingUiElement[] movingUiElements;
    [SerializeField] Vector2 defaultPosition = Vector2.zero;
    [SerializeField] RectTransform rectTransform;
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
    public void SetPosition() => rectTransform.anchoredPosition = defaultPosition;
    protected virtual void OnOpen() { }
    protected virtual void OnClose() 
    {
        Destroy(gameObject);
    }
    public void Start()
    {
        StartCoroutine(OpenAnimation());
        OnOpen();
    }
    public void Close()
    {        
        StartCoroutine(CloseAnimation());
       
    }
    IEnumerator OpenAnimation()
    {
        float index = group.alpha = 0;
        group.gameObject.SetActive(true);
        foreach (MovingUiElement i in movingUiElements)
            i.StartAnimation(this);
        while (index < 1)
        {
            index += Time.unscaledDeltaTime * windowSpeed;
            group.alpha = index;
            yield return null;
        }
                     
    }
    IEnumerator CloseAnimation()
    {
        StopCoroutine(OpenAnimation());
        ViewPoint = null;
        float index = group.alpha = 1;
        isOpen = false;        
        foreach (MovingUiElement i in movingUiElements)
            i.EndAnimation(this);
        while (index > 0)
        {
            index -= Time.unscaledDeltaTime * windowSpeed;
            group.alpha = index; 
            yield return null;
        }
        OnClose();        
    }
}
