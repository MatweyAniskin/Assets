using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillCount
{
    [SerializeField] SkillProfile profile;
    int value;
    int maxValue;

    public bool IsMayUse => value == 0;
    public bool SetSkill(SkillProfile profile)
    {
        if(this.profile == profile)
            return false;
        this.profile = profile;
        value = maxValue = profile.CoolDown;
        return true;
    }
    public static SkillCount operator ++(SkillCount i)
    {
        i.value = Mathf.Clamp(i.value+1,0,i.maxValue);
        return i;      
    }
    public static SkillCount operator --(SkillCount i)
    {
        i.value = Mathf.Clamp(i.value - 1, 0, i.maxValue);
        return i;
    }
    public static bool operator ==(SkillCount a, SkillProfile b) => a.profile == b;
    public static bool operator !=(SkillCount a, SkillProfile b) => !(a == b);
}
