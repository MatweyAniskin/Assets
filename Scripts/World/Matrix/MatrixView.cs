using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loader
{
    [CreateAssetMenu(menuName = "Loader/MatrixView")]
    public class MatrixView : Loader
    {
        [SerializeField] Tile tilePrefab;
        [SerializeField] bool isSetActiveTile = true;
        
        int width, height, curX, curY;
        Transform spawnTilePoint;
        public override void StartWork(MonoBehaviour executor)
        {
            width = GenerateProperty.MapWidth;
            height = GenerateProperty.MapHeight;
            MatrixViewRepository.InitMatrix(width, height);
            curY = curX = 0;
            spawnTilePoint = GenerateProperty.SpawnTilesObject;
        }

        public override bool Next()
        {
            if (curX == width)
                return false;
            Tile temp = Instantiate(tilePrefab, spawnTilePoint) as Tile;
            temp.SetBlocks(CacheMatrix.Get(curX, curY));
            temp.SetPosition(curX, curY);
            MatrixViewRepository.AddTile(curX, curY, temp);

            temp.SetActive(isSetActiveTile);
            curY++;
            if (curY == height)
            {
                curX++;
                curY = 0;
            }
            return true;
        }
    }
}
