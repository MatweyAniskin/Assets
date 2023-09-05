using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] float maxHelse;
    [SerializeField] float curHelse;
    [SerializeField] int maxEnergy;
    [SerializeField] int curEnergy;
    [SerializeField] DefenceType[] types;
    public void Damage(float value, DamageType damageType)
    {

    }
    public int MaxEnergy => maxEnergy;
    public int CurEnergy
    {
        get => curEnergy;
        set => curEnergy = Mathf.Clamp(value,0,MaxEnergy);
    }
}
