using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGenerator : MonoBehaviour
{
    [SerializeField] int tileIndex;
    [SerializeField] Vector2Int tilePostion;
    [SerializeField] Tile tilePrefab;

    private void OnEnable()
    {
        TileCache tileCache = TileCacheRepository.GetTile(tileIndex);
        Tile tile = Instantiate(tilePrefab) as Tile;
        tile.SetBlocks(tileCache);
        tile.SetPosition(tilePostion);
    }
}
