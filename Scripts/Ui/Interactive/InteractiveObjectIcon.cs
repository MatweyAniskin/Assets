using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveObjectIcon : Icon
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform arrowElement;
    [SerializeField] Vector2 arrowHide;
    [SerializeField] Vector2 arrowShow;
    [SerializeField] [Range(1,10f)] float animationSpeed = 1;
    [SerializeField] Vector3 offset = Vector3.up;
    IInteractiveObject curElement;
    Camera camera;    

    delegate void ChangeElement(float index);
    public void SetElement(IInteractiveObject element)
    {
        curElement = element;
        camera = Camera.main;
        base.SetElement(element);
        StartCoroutine(InterpolateCoroutine());
        StartCoroutine(Animation(CanvasShow, ArrowShow));
    }
    public override void Destroy()
    {
        StartCoroutine(Animation(CanvasHide, ArrowHide, true));
    }
    IEnumerator InterpolateCoroutine()
    {
        while (!curElement.IsUnityNull())
        {
            transform.position = camera.WorldToScreenPoint(curElement.Position + offset);
            yield return null;
        }
    }
    IEnumerator Animation(ChangeElement alpha, ChangeElement arrow, bool isDestroy = false)
    {
        float index = 0;
        while (index < 1)
        {
            index += Time.deltaTime * animationSpeed;
            alpha(index);
            arrow(index);
            yield return null;
        }
        if(isDestroy)
            base.Destroy();
    }
    void CanvasShow(float index) => canvasGroup.alpha = index;
    void CanvasHide(float index) => canvasGroup.alpha = 1-index;
    void ArrowShow(float index) => arrowElement.anchoredPosition = Vector2.Lerp(arrowHide,arrowShow,index);
    void ArrowHide(float index) => arrowElement.anchoredPosition = Vector2.Lerp(arrowShow, arrowHide, index);
}
