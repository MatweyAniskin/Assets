using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSkillController : SkillsController
{
    public override void Select(Vector2Int dir, Stats stats, params object[] args)
    {        
        if (args.Length == 0)
        {
            CurSkill = RandomProfile();
        }
        else
        {
            CurSkill = skillProfiles.FirstOrDefault(i => i == (SkillType)args[0]) ?? RandomProfile();
        }
        base.Select(dir, stats, args);
    }
    SkillProfile RandomProfile() => skillProfiles[Random.Range(0, skillProfiles.Count)];
}
