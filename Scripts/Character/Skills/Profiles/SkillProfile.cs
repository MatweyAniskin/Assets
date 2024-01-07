using Animation;
using Effects;
using Repository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Skills
{
    public abstract class SkillProfile : ScriptableObject
    {
        [SerializeField] protected string name;
        [SerializeField] protected int energyRequest;
        [SerializeField] protected int stepsCoolDown;
        [SerializeField] protected AnimationArgument[] arguments;
        [SerializeField] private SkillType skillType;
        [SerializeField] protected EffectAnimation[] effects;
        [SerializeField] protected Vector3 effectPositionOffset;
        public bool IsMayUse(Stats stats) => true; // todo fix this shit
        public int CoolDown => stepsCoolDown;
        public SkillType SkillType => skillType;        
        public AnimationArgument[] Arguments => arguments;

        public abstract ViewModel[] ViewDistanceSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args);
        public abstract void UseSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args);
        public virtual void InstantiateEffects(Vector2Int position, Vector2Int dir)
        {
            bool flip = dir.y > 0;
            Vector3 unitPosition = GenerateProperty.BlockScale * new Vector3(position.x, 0, position.y) + new Vector3(0, GenerateProperty.WalkebleGlobalHeight, 0) + effectPositionOffset;
            foreach (var effect in effects)
            {
                var temp = Instantiate(effect, unitPosition, effect.transform.rotation) as EffectAnimation;
                temp.SetFlip(flip);
            }
        }
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
            return matrixTransforms.Distinct();
          
        }
        public override string ToString() => name;  
        public static bool operator ==(SkillProfile lhs, SkillType rhs) => lhs.skillType == rhs;
        public static bool operator !=(SkillProfile lhs, SkillType rhs) => !(lhs == rhs);
        public static bool operator ==(SkillProfile lhs, SkillProfile rhs) => lhs.name == rhs.name;
        public static bool operator !=(SkillProfile lhs, SkillProfile rhs) => !(lhs == rhs);
    }
}
