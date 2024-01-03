using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Repository
{
    public class IconRepository : MonoBehaviour
    {
        public static Sprite[] Icons { get; set; }

        public static Sprite RandomSprite => Icons[Random.Range(0, Icons.Length)];
        public static bool IsIconsLoaded => !(Icons is null) && Icons.Length > 0;
    }
}
