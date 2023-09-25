using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixView : Loader
{
    [SerializeField] Tile tilePrefab;
    [SerializeField] Transform spawnTilePoint;
    [SerializeField] bool isSetActiveTile = true;
    int width, height, curX, curY;
    public override void StartWork()
    {
        width = GenerateProperty.MapWidth; 
        height = GenerateProperty.MapHeight;
        curY = curX = 0;
    }

    public override bool Next()
    {
        if (curX == width)
            return false;
        Tile temp = Instantiate(tilePrefab, spawnTilePoint) as Tile;
        temp.SetBlocks(CacheMatrix.Get(curX, curY));
        temp.SetPosition(curX, curY);


        temp.SetActive(isSetActiveTile);
        curY++;
        if(curY == height)
        {
            curX++;
            curY = 0;
        }
        return true;
    }
}
