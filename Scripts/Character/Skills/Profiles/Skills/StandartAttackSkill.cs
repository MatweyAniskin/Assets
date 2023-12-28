using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Skills 
{
    [CreateAssetMenu(menuName = "Skills/Attack/StandartAttack")]
    public class StandartAttackSkill : SkillProfile
    {
        [SerializeField] [Tooltip("Multiply dir")] int offset = 3;
        [SerializeField][Tooltip("Model radius for get characters")] int radius = 3;        
        public override void UseSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public override ViewModel[] ViewDistanceSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args)
        {            
            return new ViewModel[] {new ViewModel(transform.Position + dir* offset, radius) };
        }
    }
}