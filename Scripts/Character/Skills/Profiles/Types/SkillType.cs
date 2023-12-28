using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "Skills/SkillType")]
    public class SkillType : ScriptableObject
    {
        [SerializeField] string name;

        public static bool operator ==(SkillType x, SkillType y) => x.name == y.name;
        public static bool operator !=(SkillType x, SkillType y) => !(x == y);
    }
}
