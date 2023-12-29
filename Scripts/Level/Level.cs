using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loader
{
    [CreateAssetMenu(fileName = "Level", menuName = "Loader/Level")]
    public class Level : ScriptableObject
    {
        [SerializeField] string title;
        [SerializeField] Loader[] loaders;
        public Loader[] Loaders => loaders;
        public override string ToString() => title;
    }
}
