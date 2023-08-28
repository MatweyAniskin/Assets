using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] cloudsSprites;
    [SerializeField] Cloud cloud;
    [SerializeField] float minX = -20;
    [SerializeField] float maxX = 20;
    [SerializeField] float minY = -2.5f;
    [SerializeField] float maxY = 2.5f;
    [SerializeField] float minAnimationSpeed = 0.01f;
    [SerializeField] float maxAnimationSpeed = 0.02f;
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
        float y = Random.Range(minY, maxY);
        start = new Vector3(maxX, y);
        end = new Vector3(minX, y);
        speed = Random.Range(minAnimationSpeed, maxAnimationSpeed);
    }
    void MinToMax(out Vector3 start, out Vector3 end, out float speed)
    {
        float y = Random.Range(minY, maxY);
        start = new Vector3(minX, y);
        end = new Vector3(maxX, y);
        speed = Random.Range(minAnimationSpeed, maxAnimationSpeed);
    }
    void FullRandom(out Vector3 start, out Vector3 end, out float speed)
    {
        float y = Random.Range(minY, maxY);
        start = new Vector3(Random.Range(minX, maxX), y);
        end = new Vector3(Random.Range(minX, maxX), y);
        speed = Random.Range(minAnimationSpeed, maxAnimationSpeed);
    }
}
