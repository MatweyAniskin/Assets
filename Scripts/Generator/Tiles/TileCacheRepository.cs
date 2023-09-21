using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileCacheRepository : MonoBehaviour
{    
    static List<TileCache> tileCacheList = new List<TileCache>();
   
    public static void Clear() => tileCacheList.Clear();
    public static void SetTile(string name,SimpleBlock[,,] blocks)
    {
        TileCache tileCache = new TileCache(name,blocks);
        tileCacheList.Add(tileCache); //for rotation swap x and y + length - cord      
    }
    public static TileCache[] GetTiles() => tileCacheList.ToArray();
    public static TileCache GetTile(string name)
    {
        try
        {
            return tileCacheList.FirstOrDefault(i=> i == name);
        }
        catch
        {
            Debug.LogError($"Not found tile {name}");
            return null;
        }
    }
    public static TileCache GetTile(int i)
    {
        try
        {
            return tileCacheList[i];
        }
        catch
        {
            Debug.LogError($"Not found tile index {i}");
            return null;
        }
    }
}
