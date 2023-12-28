using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] float maxHelse;
    [SerializeField] float curHelse;
    [SerializeField] int maxEnergy;
    [SerializeField] int curEnergy;
    [SerializeField] int reservedEnergy;
    [SerializeField] DefenceType[] types;
    public void Damage(float value, DamageType damageType)
    {

    }
    public int MaxEnergy => maxEnergy;
    public int Energy
    {
        get => curEnergy; 
        set => curEnergy = value;
    }
    public int CurEnergy => curEnergy - reservedEnergy;
    public int ReservedEnergy
    {
        get 
        { 
            return reservedEnergy; 
        }
        set
        {
            reservedEnergy = value;
        }
    }

}