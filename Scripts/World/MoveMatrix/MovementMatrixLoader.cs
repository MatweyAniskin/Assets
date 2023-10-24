using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Loader/MoveMatrix")]
public class MovementMatrixLoader : Loader
{
    int widthBlockLength, heightblockLenght;
    int curTileX, curTileY, maxTileX, maxTileY;
    int tileLength;
    int walkebleLayer;
    public override void StartWork(MonoBehaviour executor)
    {
        curTileY = curTileX  = 0;
        walkebleLayer = GenerateProperty.WalkebleLayer;
        tileLength = GenerateProperty.TileSideLength;
        widthBlockLength = GenerateProperty.MapWidthBlockLength;
        heightblockLenght = GenerateProperty.MapHeightBlockLength;
        maxTileX = GenerateProperty.MapWidth;
        maxTileY = GenerateProperty.MapHeight;
        MovementMatrix.InitMatrix(widthBlockLength, heightblockLenght);
    }
    public override bool Next()
    {
        if (curTileX == maxTileX)
            return false;

        TileCache curTile = CacheMatrix.Get(curTileX, curTileY);
        bool isBlocked;
        SimpleBlock block;
        for(int x = 0; x < tileLength;x++)
        {
            for (int y = 0; y < tileLength; y++)
            {
                block = curTile.GetBlock(x, walkebleLayer, y);
                isBlocked = block is null? false : block.IsSolid;
                MovementMatrix.SetBlock(x+curTileX*tileLength, y + curTileY * tileLength, isBlocked);
            }
        }        
        curTileY++;
        if (curTileY == maxTileY)
        {
            curTileY = 0;
            curTileX++;
        }
        return true;
    }    
}
