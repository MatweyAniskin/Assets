using Animation;
using Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : StepCallBack
{
    [SerializeField] float maxHelse;
    [SerializeField] float curHelse;
    [SerializeField] int maxEnergy;
    [SerializeField] int curEnergy;
    [SerializeField] int reservedEnergy;
    [SerializeField] DefenceType[] defenceTypes;
    public UnityEvent OnDamaged;
    public UnityEvent OnDead;
    
    public void Damage(Vector2Int dir ,float value, SkillType skillType)
    {
        Callback(dir,skillType?.AnimationArgument);
        OnDamaged?.Invoke();
        Helse -= value;
    }
    public void Damage(float value, SkillType skillType) => Damage(Vector2Int.zero,value,skillType);
    public float Helse
    {
        get => curHelse;
        protected set
        {
            curHelse = Mathf.Clamp(value,0,maxHelse);              
            if (curHelse == 0)
            {
                Dead();
                OnDead?.Invoke();
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