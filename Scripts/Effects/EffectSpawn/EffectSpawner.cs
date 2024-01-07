using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{   
    public abstract class EffectSpawner : MonoBehaviour
    {
        [SerializeField] protected Stats stats;
        [SerializeField] protected EffectAssembly[] effects;        
        private void Start()
        {
            stats.OnAction += InstantiateEffect;
        }
        private void OnDestroy()
        {
            stats.OnAction -= InstantiateEffect;
        }
        public abstract void InstantiateEffect(Vector2Int dir, params object[] args);
        protected virtual GameObject Instantiate(EffectAssembly assembly)
        {
            var effect = assembly.Effect;
            return Instantiate(effect, transform.position + assembly.Offset, effect.transform.rotation,GenerateProperty.SpawnTilesObject);
        }
    }
}
