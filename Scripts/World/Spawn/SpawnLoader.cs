using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loader/SpawnLoader")]
public class SpawnLoader : Loader
{    
    [SerializeField] SpawnObject[] spawnObjects;
    [SerializeField] string spawnFieldTag;    
    List<SpawnObject> curSpawn;
    List<Vector2Int> matrixCells;
    Transform spawnField;
    int width, height, scale;
    public override bool Next()
    {
        int curIndex = Random.Range(0, matrixCells.Count);
        Vector2Int curTile = matrixCells[curIndex];        
        Vector2Int randomPosition;
        foreach (SpawnObject spawnObject in curSpawn)
        {
            if (!spawnObject.IsInstantiable)
                continue;
            randomPosition = new Vector2Int(Random.Range(0, scale), Random.Range(0, scale))+curTile*scale;
            if (MovementMatrix.CheckState(randomPosition, spawnObject.Transform.Radius))
            {
                spawnObject.Instantiate(randomPosition, spawnField);
            }
        }
        matrixCells.RemoveAt(curIndex);
        if (matrixCells.Count == 0)
            return false;
        return true;
    }

    public override void StartWork(MonoBehaviour executor)
    {
        curSpawn = new List<SpawnObject>();
        foreach(var i in  spawnObjects)
        {
            curSpawn.Add(new SpawnObject(i));
        }
        matrixCells = new List<Vector2Int>();
        spawnField = GameObject.FindWithTag(spawnFieldTag).transform;
        width = GenerateProperty.MapWidth;
        height = GenerateProperty.MapHeight;
        scale = GenerateProperty.TileSideLength;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                matrixCells.Add(new Vector2Int(x, y));
            }
        }
    }
}
