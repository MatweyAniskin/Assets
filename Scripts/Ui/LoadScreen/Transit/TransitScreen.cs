using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitScreen : MonoBehaviour
{
    [SerializeField] Image mainFrame;
    [SerializeField] Sprite[] animationTransitScreens;
    [SerializeField] Gradient frameGradient;
    [SerializeField] [Range(0.001f,10f)]float animationTime = 1;    
    private void Start()
    {
        LoadScreen.OnEndLoadScreen += TransitToFree;
        LoadScreen.OnStartLoadScreen += TransitToClose;
    }
    private void OnDestroy()
    {
        LoadScreen.OnEndLoadScreen -= TransitToFree;
        LoadScreen.OnStartLoadScreen -= TransitToClose;
    }
    void TransitToFree() => StartCoroutine(TransitAnimation(true));
    void TransitToClose() => StartCoroutine(TransitAnimation(false));

    IEnumerator TransitAnimation(bool isOpen)
    {
        mainFrame.gameObject.SetActive(true);
        mainFrame.color = frameGradient.Evaluate(0);
        int length = animationTransitScreens.Length;
        float waitTime = animationTime / length;
        for(int i = 0; i < length; i++)
        {
            mainFrame.sprite = animationTransitScreens[isOpen ? i : length-i];
            mainFrame.color = frameGradient.Evaluate(i * 1f / length);
            yield return new WaitForSeconds(waitTime);
        }
        mainFrame.gameObject.SetActive(!isOpen);
    }
}
