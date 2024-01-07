using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Menu.Logo
{
    public class StartLogo : MonoBehaviour
    {
        [SerializeField] Text[] texts;
        [SerializeField] Font[] fonts;
        [SerializeField] Font resultFont;
        [SerializeField] int iterations = 5;
        [SerializeField] float waitSecondsForSwap = 0.5f;
        [SerializeField] float resultWaitSecondsForSwap = 0.8f;
        [SerializeField] UnityEvent OnLogoEnd;
        private void Start()
        {
            StartCoroutine(Animation());
        }
        IEnumerator Animation()
        {
            for (int i = 0; i < iterations; i++)
            {
                for (int t = 0; t < texts.Length; t++)
                {
                    texts[t].font = fonts[Random.Range(0, fonts.Length)];
                    yield return new WaitForSeconds(waitSecondsForSwap);
                }
            }
            for (int t = 0; t < texts.Length; t++)
            {
                texts[t].font = resultFont;
                yield return new WaitForSeconds(resultWaitSecondsForSwap);
            }
            OnLogoEnd?.Invoke();
        }
    }
}