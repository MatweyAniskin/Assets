using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour, IService
{
    [SerializeField] int order;
    [SerializeField] string nameService;
    [SerializeField] protected int height;
    [SerializeField] protected int width;
    protected int curX, curY;
    public static float TileSideScale => SimpleBlock.BlockScale * TileCacheRepository.BlocksLengthSide;
    public int Order => order;

    public string Name => nameService;

    public abstract void SetTileCache();
    public bool Next()
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

    public void StartWork()
    {
        curX = curY = 0;
        Matrix.InitMatrix(height, width);
    }
}
