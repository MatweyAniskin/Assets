using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loader
{
    public abstract class Loader : ScriptableObject
    {
        [SerializeField] int order;
        [SerializeField] string loaderName;
        public int Order => order;
        public string Name => loaderName;
        public abstract void StartWork(MonoBehaviour executor);
        public abstract bool Next();
    }
}
