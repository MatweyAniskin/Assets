using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnObject
{
    [SerializeField] MatrixTransform matrixTransformObject;
    [SerializeField, Range(0, 100)] int spawnPercent = 50;
    [SerializeField, Range(0, 999)] int spawnCount = 1;

    public SpawnObject(SpawnObject spawnObject) 
    {
        matrixTransformObject = spawnObject.matrixTransformObject;
        spawnPercent = spawnObject.spawnPercent;
        spawnCount = spawnObject.spawnCount;
    }
    public MatrixTransform Transform => matrixTransformObject;

    public bool IsInstantiable=> spawnCount > 0 && Random.Range(0, 100) < spawnPercent;
    
    public void Instantiate(Vector2Int position, Transform parent)
    {
        spawnCount--;
        MatrixTransform temp = MonoBehaviour.Instantiate(matrixTransformObject, parent) as MatrixTransform;
        temp.SetStartPosition(position);
    }
}
