using UnityEngine;

public class MovementMatrix : MonoBehaviour
{
    public static bool[,] matrix;

    public static void InitMatrix(int width, int height)
    {
        matrix = new bool[width, height];
    }
    public static void SetBlock(int x, int y, bool value) => matrix[x, y] = value;
    public static bool GetBlock(int x, int y) => matrix[x, y];
    /// <summary>
    /// Return blocked voxel or not
    /// </summary>
    /// <param name="pos">Matrix position</param>
    /// <param name="radius">Radius of blocks from position</param>
    /// <returns>true is free, false is blocked</returns>
    public static bool CheckState(Vector2Int pos, int radius) => CheckState(pos.x - radius, pos.y - radius, pos.x + radius, pos.y + radius);
    /// <summary>
    /// Return blocked voxel or not
    /// </summary>
    /// <param name="min">Min rectangle point</param>
    /// <param name="max">Max rectangle point</param>
    /// <returns>true is free, false is blocked</returns>
    public static bool CheckState(Vector2Int min, Vector2Int max) => CheckState(min.x, min.y, max.x, max.y);
    /// <summary>
    /// Return blocked voxel or not
    /// </summary>
    /// <param name="xMin">Min x rectangle point</param>
    /// <param name="yMin">Min y rectangle point</param>
    /// <param name="xMax">Max x rectangle point</param>
    /// <param name="yMax">Max y rectangle point</param>
    /// <returns>true is free, false is blocked</returns>
    public static bool CheckState(int xMin, int yMin, int xMax, int yMax)
    {
        for (int x = xMin; x < xMax; x++)
        {
            for (int y = yMin; y < yMax; y++)
            {
                if (GetBlock(x, y))
                    return false;
            }
        }
        return true;
    }
    public static void SetBlock(Vector2Int min, Vector2Int max, bool value) => SetBlock(min.x, min.y, max.x, max.y, value);

    public static void SetBlock(int xMin, int yMin, int xMax, int yMax, bool value)
    {
        for (int x = xMin; x < xMax; x++)
        {
            for (int y = yMin; y < yMax; y++)
            {
                SetBlock(x, y, value);
            }
        }       
    }
}
