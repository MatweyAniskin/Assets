using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class DecalRandomMaterial : DecalEffect
    {
        [SerializeField] Material[] materials;

        private void Start()
        {
            projector.material = materials[Random.Range(0, materials.Length)];
        }
    }
}

