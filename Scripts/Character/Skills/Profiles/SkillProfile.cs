using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillProfile : ScriptableObject
{
    [SerializeField] int energyRequest;
    [SerializeField] int stepsCoolDown;
    public bool EnergyCheck(Stats stats) => true; // todo fix this shit
    public int CoolDown => stepsCoolDown;

    public abstract ViewModel[] ViewDistanceSkill(MatrixTransform transform, Stats stats);
    public abstract void UseSkill(MatrixTransform transform, Stats stats);
    protected IEnumerable<MatrixTransform> GetUniq(List<MatrixTransform> matrixTransforms)
    {
        if(matrixTransforms.Count <= 1) return matrixTransforms;
        for(int i = 0; i < matrixTransforms.Count-1; i++)
        {
            for (int j = 1; j < matrixTransforms.Count; j++)
            {
                if (matrixTransforms[i] == matrixTransforms[j])
                    matrixTransforms.Remove(matrixTransforms[j]);
            }
        }
        return matrixTransforms;
    }
}
