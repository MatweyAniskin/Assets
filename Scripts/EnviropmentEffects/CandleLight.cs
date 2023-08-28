using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CandleLight : MonoBehaviour
{
    [SerializeField] float timer = 0.5f;
    [SerializeField] [Range(0, 1)] float intencityPercent = 0.3f;
    [SerializeField] Light2D light;
    float curTick;
    float curIntencity;
    private void Start()
    {
        curTick = timer;
        curIntencity = light.intensity;
    }
    private void Update()
    {
        if (curTick < timer)
        {
            curTick += Time.deltaTime;
        }            
        else
        {
            curTick = 0;
            light.intensity = curIntencity + curIntencity * Random.Range(-intencityPercent, intencityPercent);
        }
            

    }
}
