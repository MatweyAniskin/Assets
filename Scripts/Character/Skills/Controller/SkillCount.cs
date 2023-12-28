using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [System.Serializable]
    public class SkillCount
    {
        [SerializeField] SkillProfile profile;
        int value;
        int maxValue;
        public SkillProfile SkillProfile => profile;
        public bool IsMayUse(Stats stats) => value == 0 && profile.IsMayUse(stats);
        public bool SetSkill(SkillProfile profile)
        {
            if (this.profile == profile)
                return false;
            this.profile = profile;
            value = maxValue = profile.CoolDown;
            return true;
        }
        public void SetCooldawn() => value = maxValue;
        public static SkillCount operator ++(SkillCount i)
        {
            i.value = Mathf.Clamp(i.value + 1, 0, i.maxValue);
            return i;
        }
        public static SkillCount operator --(SkillCount i)
        {
            i.value = Mathf.Clamp(i.value - 1, 0, i.maxValue);
            return i;
        }
        public static bool operator ==(SkillCount a, SkillProfile b) => a.profile == b;
        public static bool operator !=(SkillCount a, SkillProfile b) => !(a == b);
        public static bool operator ==(SkillCount a, SkillType b) => a.profile == b;
        public static bool operator !=(SkillCount a, SkillType b) => !(a == b);
    }
}