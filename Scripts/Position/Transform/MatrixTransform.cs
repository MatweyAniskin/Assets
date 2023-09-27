using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTransform : MonoBehaviour
{
    [SerializeField] Vector2Int matrixPosition;
    [SerializeField] int radius;
    Vector2Int squarePosition;
    private void Start()
    {
        matrixPosition = PositionToMatrix();
        squarePosition = TransformRepository.GetSquarePosition(matrixPosition);
        TransformRepository.Add(squarePosition, this);
    }
    public Vector2Int Position
    {
        get => matrixPosition;
        set
        {            
            matrixPosition = value;
            transform.position = MatrixToPosition();
            Vector2Int next = TransformRepository.GetSquarePosition(matrixPosition);
            if (next != squarePosition)
            {
                Debug.Log($"Last: {squarePosition}, Next: {next}");
                TransformRepository.SwitchSquad(squarePosition, next, this);
                squarePosition = next;
            }
        }        
    }
    public int Radius => radius;
    public Vector2Int SquarePosition => squarePosition;
    public bool IsContact(Vector2Int pos) => matrixPosition.x - Radius <= pos.x && matrixPosition.x + Radius >= pos.x && matrixPosition.y - Radius <= pos.y && matrixPosition.y + Radius >= pos.y;
    public Vector2Int PositionToMatrix() => PositionToMatrix(transform.position);
    public static Vector2Int PositionToMatrix(Vector3 globalPosition) => PositionToMatrix(globalPosition, GenerateProperty.BlockScale);
    public static Vector2Int PositionToMatrix(Vector3 globalPosition, float blockScale) => new Vector2Int(Mathf.CeilToInt(globalPosition.x / blockScale), Mathf.CeilToInt(globalPosition.z / blockScale));
    public Vector3 MatrixToPosition() => MatrixToPosition(Position, transform.position);
    public static Vector3 MatrixToPosition(Vector2Int matrixPos, Vector3 globalPos) => MatrixToPosition(matrixPos, globalPos, GenerateProperty.BlockScale);
    public static Vector3 MatrixToPosition(Vector2Int matrixPos, Vector3 globalPos, float blockScale) => new Vector3(matrixPos.x * blockScale, globalPos.y, matrixPos.y * blockScale);
    public void Destroy() => Destroy(gameObject);
    public T GetComponent<T>() => GetComponent<T>();
}
