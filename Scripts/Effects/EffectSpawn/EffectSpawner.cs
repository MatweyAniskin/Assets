using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{   
    public abstract class EffectSpawner : MonoBehaviour
    {
        [SerializeField] protected GameObject[] effects;
        [SerializeField] protected Vector3 offset;
        public abstract void InstantiateEffect();
        protected virtual GameObject Instantiate(int index)
        {
            var effect = effects[index];
            return Instantiate(effect, transform.position + offset, effect.transform.rotation,GenerateProperty.SpawnTilesObject);
        }
    }
}
