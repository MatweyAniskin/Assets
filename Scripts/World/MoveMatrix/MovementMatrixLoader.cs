using Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Loader
{
    [CreateAssetMenu(menuName = "Loader/MoveMatrix")]
    public class MovementMatrixLoader : Loader
    {
        int widthBlockLength, heightblockLenght;
        int curTileX, curTileY, maxTileX, maxTileY;
        int tileLength;
        int walkebleLayer, characterHeight;
        public override void StartWork(MonoBehaviour executor)
        {
            curTileY = curTileX = 0;
            walkebleLayer = GenerateProperty.WalkebleLayer;
            tileLength = GenerateProperty.TileSideLength;
            widthBlockLength = GenerateProperty.MapWidthBlockLength;
            heightblockLenght = GenerateProperty.MapHeightBlockLength;
            maxTileX = GenerateProperty.MapWidth;
            maxTileY = GenerateProperty.MapHeight;
            characterHeight = GenerateProperty.CharactersHeight;
            MovementMatrix.InitMatrix(widthBlockLength, heightblockLenght);
        }
        public override bool Next()
        {
            if (curTileX == maxTileX)
                return false;

            TileCache curTile = CacheMatrix.Get(curTileX, curTileY);
            bool isBlocked;
            SimpleBlock block;
            for (int x = 0; x < tileLength; x++)
            {
                for (int y = 0; y < tileLength; y++)
                {
                    isBlocked = false;
                    for (int z = walkebleLayer; z < walkebleLayer + characterHeight; z++)
                    {
                        block = curTile.GetBlock(x, z, y);
                        if (block is null ? false : block.IsSolid)
                        {
                            isBlocked = true;
                            break;
                        }

                    }
                    MovementMatrix.SetBlock(x + curTileX * tileLength, y + curTileY * tileLength, isBlocked);
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
}
