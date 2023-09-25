using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class TileCacheRepository : MonoBehaviour
{    
    static List<TileCache> tileCacheList = new List<TileCache>();

    delegate void DegreeDelegate(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length);
    public static void Clear() => tileCacheList.Clear();
    public static int Count => tileCacheList.Count;
    
    public static void SetTile(string name,SimpleBlock[,,] blocks)
    {        
        tileCacheList.Add(new TileCache(name, blocks)); //for rotation swap x and y + length - cord
        tileCacheList.Add(new TileCache($"{name}90", RotateCacheTile(blocks, To90)));
        tileCacheList.Add(new TileCache($"{name}180", RotateCacheTile(blocks, To180)));
        tileCacheList.Add(new TileCache($"{name}270", RotateCacheTile(blocks, To270)));
        Debug.Log($"tiles cahce loaded: {tileCacheList.Count}");
    }
    static SimpleBlock[,,] RotateCacheTile(SimpleBlock[,,] blocks, DegreeDelegate rotateMethod)
    {
        int length = blocks.GetLength(0);
        SimpleBlock[,,] rotatedBlocks = new SimpleBlock[length, length, length];
        for(int x = 0; x < length; x++)
            for(int y = 0; y < length; y++)
                for (int z = 0; z < length; z++)
                {
                    rotateMethod(ref rotatedBlocks, blocks, x, y, z, length);
                }
        return rotatedBlocks;
    }
    static void To90(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length) => rotatedBlocks[length - 1 - z, y, x] = blocks[x, y, z];
    static void To180(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length) => rotatedBlocks[length - 1 - x, y, length - 1 - z] = blocks[x, y, z];
    static void To270(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length) => rotatedBlocks[ z, y, length - 1 - x] = blocks[x, y, z];

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
