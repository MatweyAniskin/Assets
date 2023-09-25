using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementMatrixLoader : Loader
{
    int widthBlockLength, heightblockLenght;
    int curTileX, curTileY, maxTileX, maxTileY;
    int tileLength;
    int walkebleLayer;
    public override void StartWork()
    {
        curTileY = curTileX  = 0;
        walkebleLayer = GenerateProperty.WalkebleLayer;
        tileLength = GenerateProperty.TileSideLength;
        widthBlockLength = GenerateProperty.MapWidthBlockLength;
        heightblockLenght = GenerateProperty.MapHeightBlockLength;
        MovementMatrix.InitMatrix(widthBlockLength, heightblockLenght);
    }
    public override bool Next()
    {
        if (curTileX == maxTileX)
            return false;

        TileCache curTile = CacheMatrix.Get(curTileX, curTileY);

        for(int x = 0; x < tileLength;x++)
        {
            for (int y = 0; y < tileLength; y++)
            {
               MovementMatrix.SetBlock(x+curTileX*tileLength, y + curTileY * tileLength, curTile.GetType(x, walkebleLayer, y) == typeof(SolidBlock));
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
