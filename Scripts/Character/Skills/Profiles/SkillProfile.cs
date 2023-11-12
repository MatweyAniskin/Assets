using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProfile : ScriptableObject
{
    [SerializeField] int energyRequest;
    [SerializeField] int stepsCoolDown;
    public bool EnergyCheck(Stats stats) => true; // todo fix this shit
    public int CoolDown => stepsCoolDown;

    public void ViewDistanceSkill(MatrixTransform transform, )
    {

    }
}
