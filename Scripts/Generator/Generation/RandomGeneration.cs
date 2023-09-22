using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : Generator
{
    public override void SetTileCache()
    {
        Matrix.Add(TileCacheRepository.GetTile(Random.Range(0,TileCacheRepository.Count)),curX,curY);
    }
}
