using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGenerator : MonoBehaviour
{
    [SerializeField] string tileName;
    [SerializeField] Vector3 tilePostion;
    [SerializeField] Tile tilePrefab;

    private void OnEnable()
    {
        TileCache tileCache = TileCacheRepository.GetTile(tileName);
        Tile tile = Instantiate(tilePrefab) as Tile;
        tile.SetBlocks(tileCache);
        tile.SetPosition(tilePostion);
    }
}
