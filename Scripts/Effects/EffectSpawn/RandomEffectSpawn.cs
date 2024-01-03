using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class RandomEffectSpawn : EffectSpawner
    {
        public override void InstantiateEffect() => Instantiate(Random.Range(0, effects.Length));        
    }

}
