using Skills;
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
            CurSkill = RandomProfile().SkillProfile;
        }
        else
        {
            CurSkill = (skillProfiles.FirstOrDefault(i => i == (SkillType)args[0]) ?? RandomProfile()).SkillProfile;
        }
        base.Select(dir, stats, args);
    }
    SkillCount RandomProfile() => skillProfiles[Random.Range(0, skillProfiles.Count)];
}
