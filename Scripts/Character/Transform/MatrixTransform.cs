using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTransform : MonoBehaviour
{
    [SerializeField] Vector2Int matrixPosition;
    [SerializeField] int radius;
    
    public Vector2Int Position
    {
        get => matrixPosition;
        set
        {
            matrixPosition = value;
            transform.position = MatrixToPosition();
        }
        
    }
    public int Radius => radius;

    public Vector2Int PositionToMatrix() => PositionToMatrix(transform.position);
    public static Vector2Int PositionToMatrix(Vector3 globalPosition) => PositionToMatrix(globalPosition, GenerateProperty.BlockScale);
    public static Vector2Int PositionToMatrix(Vector3 globalPosition, float blockScale) => new Vector2Int(Mathf.CeilToInt(globalPosition.x / blockScale), Mathf.CeilToInt(globalPosition.z / blockScale));
    public Vector3 MatrixToPosition() => MatrixToPosition(Position, transform.position);
    public static Vector3 MatrixToPosition(Vector2Int matrixPos, Vector3 globalPos) => MatrixToPosition(matrixPos, globalPos, GenerateProperty.BlockScale);
    public static Vector3 MatrixToPosition(Vector2Int matrixPos, Vector3 globalPos, float blockScale) => new Vector3(matrixPos.x * blockScale, globalPos.y, matrixPos.y * blockScale);


}
