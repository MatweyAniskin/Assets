using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] cloudsSprites;
    [SerializeField] Cloud cloud;
    [SerializeField] CloudProperty spawnXprop;
    [SerializeField] CloudProperty spawnZprop;
    [SerializeField] CloudProperty animationSpeed;
    [SerializeField] float spawnYPos;
    [SerializeField] float spawnTimer;
    [SerializeField] [Range(0,1)] float timerRandomPercent;
    [SerializeField] AnimationType animationType;

    enum AnimationType { MinToMax = 0, MaxToMin = 1, FullRandom = 2 }
    delegate void Calculate(out Vector3 start, out Vector3 end, out float speed);
    Calculate calculate;
   
    private void OnEnable()
    {
        switch (animationType)
        {
            case AnimationType.MinToMax:
                calculate = MinToMax;
                break;
            case AnimationType.MaxToMin:
                calculate = MaxToMin;
                break;
            case AnimationType.FullRandom:
                calculate = FullRandom;
                break;
        }
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        Vector3 start;
        Vector3 end;
        float animationSpeed;
        Cloud tempCloud;
        while (this.enabled)
        {
            calculate(out start, out end, out animationSpeed);
            tempCloud = Instantiate(cloud, transform) as Cloud;
            tempCloud.SetCloud(start, end, animationSpeed, cloudsSprites[Random.Range(0, cloudsSprites.Length)]);
            yield return new WaitForSeconds(spawnTimer + spawnTimer * Random.Range(-timerRandomPercent,timerRandomPercent));
        }
    }
    void MaxToMin(out Vector3 start, out Vector3 end, out float speed)
    {
        float z = spawnZprop.Random;
        start = new Vector3(spawnXprop.Max, spawnYPos, z);
        end = new Vector3(spawnXprop.Min, spawnYPos, z);
        speed = animationSpeed.Random;
    }
    void MinToMax(out Vector3 start, out Vector3 end, out float speed)
    {
        float z = spawnZprop.Random;
        start = new Vector3(spawnXprop.Min, spawnYPos, z);
        end = new Vector3(spawnXprop.Max, spawnYPos, z);
        speed = animationSpeed.Random;
    }
    void FullRandom(out Vector3 start, out Vector3 end, out float speed)
    {        
        start = new Vector3(spawnXprop.Random, spawnYPos, spawnZprop.Random);
        end = new Vector3(spawnXprop.Random, spawnYPos, spawnZprop.Random);
        speed = animationSpeed.Random;
    }
}
