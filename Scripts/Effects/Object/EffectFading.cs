using System.Collections;
using UnityEngine;

namespace Effects
{
    public class EffectFading : MonoBehaviour
    {
        [SerializeField] SpriteRenderer[] spriteRenderers;
        [SerializeField] Gradient gradient;
        [SerializeField] float waitForFade = 10;
        [SerializeField] float fadeTime = 4.5f;
        void Start()
        {
            StartCoroutine(Fading());
        }
        IEnumerator Fading()
        {
            yield return new WaitForSeconds(waitForFade);
            float index = 0;
            for(float t = 0; t<=fadeTime; t+= Time.deltaTime)
            {
                index = t/fadeTime;                
                foreach(var i in spriteRenderers)
                    i.color = gradient.Evaluate(index);
                yield return null;
            }
        }
    }
}