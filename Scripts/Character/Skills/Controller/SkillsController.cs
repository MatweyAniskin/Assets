using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsController : StepAction
{
    [SerializeField] MatrixTransform matrixTransform;
    [SerializeField] List<SkillProfile> skillProfiles;
    public override void Action(Vector2Int dir, Stats stats, object[] args = null)
    {
        SelectSkill(args);
        base.Action(dir, stats);
    }
    public virtual void SelectSkill(object[] args)
    {

    }
}
