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
    public static bool CheckState(Vector2Int min, Vector2Int max) => CheckState(min.x, min.y, max.x, max.y);
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
