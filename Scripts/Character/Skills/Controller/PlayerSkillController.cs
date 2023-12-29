using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : SkillsController
{
    int skillCountIndex;
    public override void Select(Vector2Int dir, Stats stats, params object[] args)
    {
        skillCountIndex = (int)args[0];
        var temp = skillProfiles[skillCountIndex];
        base.Select(dir, stats, args);
        if (temp.IsMayUse(stats))
        {
            CurSkill = temp.SkillProfile;
        }        
    }
    public override void Action(Vector2Int dir, Stats stats, params object[] args)
    {
        if (CurSkill is null)
            return;        
        CurSkill.UseSkill(matrixTransform, stats, dir);
        skillProfiles[skillCountIndex].SetCooldawn();
        
    }
    
}
