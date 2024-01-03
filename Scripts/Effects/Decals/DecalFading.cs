using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class DecalFading : DecalEffect
    {        
        [SerializeField] float fadeTime = 1f;

        private void Start()
        {
            StartCoroutine(Animation());
        }
        IEnumerator Animation()
        {
            for(float t = 0; t<=fadeTime; t+= Time.deltaTime)
            {
                projector.fadeFactor = Mathf.Lerp(0, 1, t/fadeTime);
                yield return null;
            }
        }

    }
}