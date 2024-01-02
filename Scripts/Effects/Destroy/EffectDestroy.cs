using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class EffectDestroy : MonoBehaviour
    {
        [SerializeField] float timer = 5;
        void Start()
        {
            Destroy(gameObject, timer);
        }

    }
}
