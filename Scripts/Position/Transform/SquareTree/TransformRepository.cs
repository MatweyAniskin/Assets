using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRepository : MonoBehaviour
{
    static TransformSquare[,] squares;
    public static int Width { get; internal set; }
    public static int Height { get; internal set; }
    public static int SquareSideLength { get; internal set; }
    public static void SetTransforms(int width, int height, int squareSideLength)
    {
        SquareSideLength = squareSideLength;
        Width = width;
        Height = height;
        squares = new TransformSquare[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                squares[x, y] = new TransformSquare();
            }
        }
    }
    public static void SwitchSquad(Vector2Int curSquareIndex, Vector2Int nextSquareIndex, MatrixTransform transform)
    {
        Remove(curSquareIndex, transform);
        Add(nextSquareIndex, transform);
    }
    public static void Add(Vector2Int squareIndex, MatrixTransform transform) => squares[squareIndex.x, squareIndex.y].Add(transform);
    public static void Remove(Vector2Int squareIndex, MatrixTransform transform) => squares[squareIndex.x, squareIndex.y].Remove(transform);
    public static Vector2Int GetSquarePosition(Vector2Int position) => new Vector2Int(position.x/SquareSideLength, position.y / SquareSideLength);
}
