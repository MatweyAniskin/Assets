using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Skills 
{
    [CreateAssetMenu(menuName = "Skills/Attack/StandartAttack")]
    public class StandartAttackSkill : SkillProfile
    {
        [SerializeField] int damage = 10;
        [SerializeField] [Tooltip("Multiply dir")] int offset = 3;
        [SerializeField][Tooltip("Model radius for get characters")] int radius = 3;        
        public override void UseSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args)
        {
            var characters = GetAffectMatrixTransform(transform, stats, dir, args);                       
            foreach (var character in characters)
            {
                if(character == transform) continue;
                character.GetComponent<Stats>()?.Damage(damage, SkillType);
            }
            InstantiateEffects(Center(transform.Position, dir), dir);
        }

        public override ViewModel[] ViewDistanceSkill(MatrixTransform transform, Stats stats, Vector2Int dir, params object[] args)
        {            
            return new ViewModel[] {new ViewModel(Center(transform.Position,dir), radius) };
        }
        Vector2Int Center(Vector2Int transformPosition,Vector2Int dir) => transformPosition + dir * offset;
    }
}