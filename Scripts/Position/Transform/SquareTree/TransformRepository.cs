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
    public static void Add(MatrixTransform transform) => GetSquare(transform.SquarePosition).Add(transform);
    public static void Remove(MatrixTransform transform) => GetSquare(transform.SquarePosition).Remove(transform);
    public static void Add(Vector2Int squareIndex, MatrixTransform transform) => GetSquare(squareIndex).Add(transform);
    public static void Remove(Vector2Int squareIndex, MatrixTransform transform) => GetSquare(squareIndex).Remove(transform);
    /// <summary>
    /// Return matrix transform in position param transform
    /// </summary>
    /// <param name="transform">Exclusive transform</param>
    /// <returns></returns>
    public static MatrixTransform GetTransformInPosition(MatrixTransform transform) => GetSquare(transform.SquarePosition).GetContact(transform);
    /// <summary>
    /// Return matrix transform in global position
    /// </summary>
    /// <param name="position">global position</param>
    /// <returns></returns>
    public static MatrixTransform GetTransformInPosition(Vector2Int position) => GetSquare(position).GetContact(position);
    static TransformSquare GetSquare(Vector2Int squareIndex) => squares[squareIndex.x, squareIndex.y];
    public static Vector2Int GetSquarePosition(Vector2Int position) => new Vector2Int(position.x/SquareSideLength, position.y / SquareSideLength);
}
