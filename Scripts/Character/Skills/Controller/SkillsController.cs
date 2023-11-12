using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsController : StepAction
{
    [SerializeField] MatrixTransform matrixTransform;
    [SerializeField] List<SkillProfile> skillProfiles;
    public override void Action(Vector2Int dir, Stats stats)
    {
        base.Action(dir, stats);
    }
}
