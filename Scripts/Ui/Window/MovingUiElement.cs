using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovingUiElement
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] float waitTime = 0.5f;
    [SerializeField] float animationSpeed = 2;
    [SerializeField] Vector2 hiddenPosition;
    [SerializeField] Vector2 viewPosition;

    public void StartAnimation(MonoBehaviour behaviour) => behaviour.StartCoroutine(StartAnimation());
    public void EndAnimation(MonoBehaviour behaviour) => behaviour.StartCoroutine(EndAnimation());
    IEnumerator StartAnimation()
    {
        rectTransform.gameObject.SetActive(false);
        rectTransform.anchoredPosition = hiddenPosition;        
        yield return new WaitForSeconds(waitTime);
        rectTransform.gameObject.SetActive(true);
        float index = 0;
        while (index < 1)
        {
            index += Time.deltaTime * animationSpeed;
            rectTransform.anchoredPosition = Vector2.Lerp(hiddenPosition, viewPosition, index);
            yield return null;
        }
    }
    IEnumerator EndAnimation()
    {
        rectTransform.anchoredPosition = viewPosition;        
        float index = 0;
        while (index < 1)
        {
            index += Time.deltaTime * animationSpeed;
            rectTransform.anchoredPosition = Vector2.Lerp(viewPosition, hiddenPosition, index);
            yield return null;
        }
    }
}
