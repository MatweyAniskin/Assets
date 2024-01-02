using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;

namespace Effects
{
    public class EffectAnimation : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] SpriteAnimationProfile[] profiles;        

        private void Start()
        {
            Transform renderTransform = spriteRenderer.transform;
            foreach (var profile in profiles)
            {
                StartCoroutine(profile.Animation(Vector2Int.zero, renderTransform.position, renderTransform.rotation, renderTransform,spriteRenderer));
            }
        }        
        public void SetFlip(bool flipX) => spriteRenderer.flipX = flipX;
    }
}
