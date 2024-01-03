using Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loader
{
    [CreateAssetMenu(menuName = "Loader/IconBar")]
    public class IconBarLoader : Loader
    {
        [SerializeField] Sprite[] icons;
        public override bool Next()
        {
            return false;
        }

        public override void StartWork(MonoBehaviour executor)
        {
            IconRepository.Icons = icons;
        }
    }
}
