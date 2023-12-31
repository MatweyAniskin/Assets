using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

 namespace Skills
{
    public class CharacterSkillController : SkillsController
    {
        public override void Action(Vector2Int dir, Stats stats, params object[] args)
        {
            if (CurSkill is null)
                return;
            CurSkill.UseSkill(matrixTransform, stats, this.skillDirection);
            Callback(this.skillDirection, CurSkill.Arguments);
        }
        public override void Select(Vector2Int pos, Stats stats, params object[] args)
        {
            this.skillDirection = matrixTransform.Direction(pos);
            if (args.Length == 0)
            {
                CurSkill = RandomProfile().SkillProfile;
            }
            else
            {
                CurSkill = (skillProfiles.FirstOrDefault(i => i == (SkillType)args[0]) ?? RandomProfile()).SkillProfile;
            }
           
                     
        }
        SkillCount RandomProfile() => skillProfiles[Random.Range(0, skillProfiles.Count)];
    }
}
