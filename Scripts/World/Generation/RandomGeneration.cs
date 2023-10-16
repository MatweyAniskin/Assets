using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loader/Generator/Random")]
public class RandomGeneration : Generator
{
    public override void SetTileCache() => CacheMatrix.Add(GetRandomTileCache(TileCacheRepository.GetTiles()), curX, curY);
}
