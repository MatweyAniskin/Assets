using Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsController : StepAction
{
    [SerializeField] Stats stats;
    [SerializeField] protected MatrixTransform matrixTransform;
    [SerializeField] protected List<SkillCount> skillProfiles;
    protected SkillProfile curSkill;
    protected Vector2Int dir;        
    public delegate void ChangeSkills(IEnumerable<ViewModel> views);
    public event ChangeSkills OnSetSkill;
    public delegate void DisableSkills();
    public event DisableSkills OnDisableSkill;
    protected SkillProfile CurSkill 
    { 
        get => curSkill;
        set
        {
            curSkill = value;
            if (value is null)
            {
                OnDisableSkill?.Invoke();
            }else
            {
                var select = curSkill.ViewDistanceSkill(matrixTransform, stats, dir);
                OnSetSkill?.Invoke(select);
            }
        }
    }
    public override void Action(Vector2Int dir, Stats stats, params object[] args)
    {
        if (CurSkill is null)
            return;
        CurSkill.UseSkill(matrixTransform,stats,dir);              
        base.Action(dir, stats);
    }
    public override void Select(Vector2Int dir, Stats stats, params object[] args)
    {                        
        this.dir = dir;
        base.Select(dir, stats, args);
    }
}
