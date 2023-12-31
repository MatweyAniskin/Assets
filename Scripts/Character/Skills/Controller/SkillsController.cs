using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace Skills
{
    public abstract class SkillsController : StepAction
    {
        [SerializeField] Stats stats;
        [SerializeField] protected MatrixTransform matrixTransform;
        [SerializeField] protected List<SkillCount> skillProfiles;
        protected SkillProfile curSkill;
        protected Vector2Int skillDirection;
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
                }
                else
                {
                    var select = curSkill.ViewDistanceSkill(matrixTransform, stats, skillDirection);
                    OnSetSkill?.Invoke(select);
                }
            }
        }             
        public override void DeSelect()
        {
            CurSkill = null;
        }
    }
}

