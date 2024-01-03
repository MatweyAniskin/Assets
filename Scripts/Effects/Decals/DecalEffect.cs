using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Effects
{
    public abstract class DecalEffect : MonoBehaviour
    {
        [SerializeField] protected DecalProjector projector;
    }

}
