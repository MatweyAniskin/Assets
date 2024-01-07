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
            var argument = args.Cast<AnimationArgument>();
           
            EffectAssembly assembly = effects.FirstOrDefault(i => i == argument) ?? null;
            if (!(assembly is null))
            {
                Instantiate(assembly);
            }
        }
    }

}
