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
        Helse -= value;
    }
    public float Helse
    {
        get => curHelse;
        protected set
        {
            curHelse = Mathf.Clamp(value,0,maxHelse);
            if(curHelse == 0)
            {
                Dead();
            }
        }
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
    protected virtual void Dead()
    {
        Debug.Log($"{name} is DEAD");
        Destroy(gameObject);
    }
}