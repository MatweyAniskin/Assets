using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Repository
{
    public class MatrixViewRepository : MonoBehaviour
    {
        static Tile[,] tiles;
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static void InitMatrix(int width, int height)
        {
            tiles = new Tile[width, height];
            Width = width;
            Height = height;
        }
        public static void AddTile(int squareX, int squareY, Tile tile) => tiles[squareX, squareY] = tile;
        /// <summary>
        /// Get tile from square position
        /// </summary>
        /// <param name="squareX"></param>
        /// <param name="squareY"></param>
        /// <returns></returns>
        public static Tile GetTile(int squareX, int squareY) => tiles[squareX, squareY];
        /// <summary>
        /// Get tile from square position
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public static Tile GetTile(Vector2Int square) => GetTile(square.x, square.y);
        /// <summary>
        /// Set active tile from square position
        /// </summary>
        /// <param name="squareX"></param>
        /// <param name="squareY"></param>
        /// <param name="value"></param>
        public static void SetActive(int squareX, int squareY, bool value) => GetTile(squareX, squareY).SetActive(value);
    }
}