using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCacheRepository : MonoBehaviour
{    
    static Dictionary<string, TileCache> tileCacheDictionary = new Dictionary<string, TileCache>();
   
    private void OnDestroy()
    {
        tileCacheDictionary.Clear();
    }
    public static void SetTile(string name, SimpleBlock[,,] blocks)
    {
        TileCache tileCache = new TileCache(blocks);
        tileCacheDictionary.Add(name, tileCache); //for rotation swap x and y + length - cord
        Debug.Log($"Set tile {name}");
    }
    public static TileCache GetTile(string name)
    {
        try
        {
            return tileCacheDictionary[name];
        }
        catch
        {
            Debug.LogError($"Not found tile {name}");
            return null;
        }
    }
}
