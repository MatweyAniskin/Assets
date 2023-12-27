using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : SkillsController
{
    public override void Select(Vector2Int dir, Stats stats, params object[] args)
    {
        var temp = skillProfiles[(int)args[0]];
        if (temp.IsMayUse(stats))
        {
            CurSkill = temp;
        }
    }
}
