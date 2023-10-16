using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : Loader
{    
    protected int height;
    protected int width;
    protected int curX, curY;


    protected TileCache GetRandomTileCache(TileCache[] tileCaches)
    {
        try
        {
            return tileCaches[Random.Range(0, tileCaches.Length)];
        }
        catch
        {
            return null;//GetRandomTileCache(TileCacheRepository.GetTiles());
        }
    }
    public abstract void SetTileCache();
    public override bool Next()
    {
        if (curX == width)
            return false;

        SetTileCache();
        curY++;
        if (curY == height)
        {
            curX++;
            curY = 0;
        }
        return true;
    }

    public override void StartWork(MonoBehaviour executor)
    {
        curX = curY = 0;
        height = GenerateProperty.MapHeight;
        width = GenerateProperty.MapWidth;
        CacheMatrix.InitMatrix(height, width);
    }
}
