using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu.Logo
{
    public class SmoothFade : MonoBehaviour
    {
        [SerializeField] CanvasGroup group;
        [SerializeField] float showSeconds = 0.6f;
        private void Start()
        {
            StartCoroutine(Fading());
        }
        IEnumerator Fading()
        {
            for (float t = 0; t <= showSeconds; t += Time.deltaTime)
            {
                group.alpha = t/showSeconds;
                yield return null;
            }
        }
    }

}
