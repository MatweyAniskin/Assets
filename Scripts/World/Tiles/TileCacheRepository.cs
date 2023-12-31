using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Repository
{
    public class TileCacheRepository : MonoBehaviour
    {
        static List<TileCache> tileCacheList = new List<TileCache>();

        delegate void DegreeDelegate(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length);
        public static void Clear() => tileCacheList.Clear();
        public static int Count => tileCacheList.Count;

        public static void SetTile(string name, SimpleBlock[,,] blocks, string[] directions)
        {
            tileCacheList.Add(new TileCache(name, blocks, directions)); //for rotation swap x and y + length - cord
            tileCacheList.Add(new TileCache($"{name}90", RotateCacheTile(blocks, To90), Directions(directions, 3, 0, 1, 2)));
            tileCacheList.Add(new TileCache($"{name}180", RotateCacheTile(blocks, To180), Directions(directions, 2, 3, 0, 1)));
            tileCacheList.Add(new TileCache($"{name}270", RotateCacheTile(blocks, To270), Directions(directions, 1, 2, 3, 0)));
        }
        static SimpleBlock[,,] RotateCacheTile(SimpleBlock[,,] blocks, DegreeDelegate rotateMethod)
        {
            int length = blocks.GetLength(0);
            SimpleBlock[,,] rotatedBlocks = new SimpleBlock[length, length, length];
            for (int x = 0; x < length; x++)
                for (int y = 0; y < length; y++)
                    for (int z = 0; z < length; z++)
                    {
                        rotateMethod(ref rotatedBlocks, blocks, x, y, z, length);
                    }
            return rotatedBlocks;
        }
        static string[] Directions(string[] dir, params int[] index)
        {
            List<string> newDirs = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                newDirs.Add(dir[index[i]]);
            }
            return newDirs.ToArray();
        }
        static void To90(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length) => rotatedBlocks[length - 1 - z, y, x] = blocks[x, y, z];
        static void To180(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length) => rotatedBlocks[length - 1 - x, y, length - 1 - z] = blocks[x, y, z];
        static void To270(ref SimpleBlock[,,] rotatedBlocks, SimpleBlock[,,] blocks, int x, int y, int z, int length) => rotatedBlocks[z, y, length - 1 - x] = blocks[x, y, z];

        public static TileCache[] GetTiles() => tileCacheList.ToArray();
        public static TileCache GetTile(string name)
        {
            try
            {
                return tileCacheList.FirstOrDefault(i => i == name);
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
}