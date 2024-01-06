using Animation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Effects
{
    public class ArgumentsEffectSpawn : EffectSpawner
    {        
        public override void InstantiateEffect(Vector2Int dir, params object[] args)
        {
            var argument = (AnimationArgument)args[0];
            EffectAssembly assembly = effects.FirstOrDefault(i => i == argument) ?? null;
            if (assembly != null)
            {
                Instantiate(assembly);
            }
        }
    }

}
