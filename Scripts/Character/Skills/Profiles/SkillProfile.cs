using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public abstract class SkillProfile : ScriptableObject
    {
        [SerializeField] protected string name;
        [SerializeField] protected int energyRequest;
        [SerializeField] protected int stepsCoolDown;
        [SerializeField] SkillType skillType;
        public bool IsMayUse(Stats stats) => true; // todo fix this shit
        public int CoolDown => stepsCoolDown;

        public abstract ViewModel[] ViewDistanceSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args);
        public abstract void UseSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args);
        
        protected IEnumerable<MatrixTransform> GetAffectMatrixTransform(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args)
        {            
            List<MatrixTransform> result = new List<MatrixTransform>();
            MatrixTransform temp;
            foreach (var model in ViewDistanceSkill(transform, stats, dir, args))
            {
                foreach (var block in model.GetViewBlocks())
                {
                    temp = TransformRepository.GetTransformInPosition(block);
                    if (temp is null)
                        continue;
                    result.Add(temp);
                }
            }
            return GetUniq(result);
        }
        protected IEnumerable<MatrixTransform> GetUniq(List<MatrixTransform> matrixTransforms)
        {
            if (matrixTransforms.Count <= 1) return matrixTransforms;
            for (int i = 0; i < matrixTransforms.Count - 1; i++)
            {
                for (int j = 1; j < matrixTransforms.Count; j++)
                {
                    if (matrixTransforms[i] == matrixTransforms[j])
                        matrixTransforms.Remove(matrixTransforms[j]);
                }
            }
            return matrixTransforms;
        }
        public static bool operator ==(SkillProfile lhs, SkillType rhs) => lhs.skillType == rhs;
        public static bool operator !=(SkillProfile lhs, SkillType rhs) => !(lhs == rhs);
        public static bool operator ==(SkillProfile lhs, SkillProfile rhs) => lhs.name == rhs.name;
        public static bool operator !=(SkillProfile lhs, SkillProfile rhs) => !(lhs == rhs);
    }
}
