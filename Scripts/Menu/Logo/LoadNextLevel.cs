using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu.Logo
{
    public class LoadNextLevel : MonoBehaviour
    {
        [SerializeField] int level;
        public void LoadLevel() => Application.LoadLevel(level);
    }
}
