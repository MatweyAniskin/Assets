using System;
using System.Collections.Generic;
using UnityEngine;

namespace Repository
{
    public class CacheMatrix : MonoBehaviour
    {
        static TileCache[,] cells;

        public static void InitMatrix(int height, int width) => cells = new TileCache[width, height];
        public static void Add(TileCache cache, int x, int y) => cells[x, y] = cache;
        public static TileCache Get(int x, int y) => cells[x, y];
    }
}
