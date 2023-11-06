using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MatrixTransform : MonoBehaviour
{
    [SerializeField] Vector2Int matrixPosition;
    [SerializeField] int radius;
    Vector2Int squarePosition;
    public delegate void DelegateTransformChange(Vector2Int next, Vector2Int last);
    public event DelegateTransformChange OnSquareChange;
    private void OnDestroy()
    {
        TransformRepository.Remove(this);
    }
    /// <summary>
    /// Set matrix start position, use once 
    /// </summary>
    /// <param name="globalposition">matrix global position</param>
    public virtual void SetStartPosition(Vector2Int globalposition)
    {
        transform.localPosition = Vector3.up * GenerateProperty.WalkebleHeight;
        matrixPosition = globalposition;
        RecalculateMatrixPositionToUnitPosition();
        squarePosition = TransformRepository.GetSquarePosition(matrixPosition);      
        TransformRepository.Add(squarePosition, this);
    }
    /// <summary>
    /// Set matrix start position, use once 
    /// </summary>
    /// <param name="unitPosition">unit global position</param>
    public void SetStartPosition(Vector3 unitPosition) => SetStartPosition(PositionToMatrix(unitPosition));
    public Vector2Int Position
    {
        get => LogicPosition;
        set
        {
            LogicPosition = value;
            RecalculateMatrixPositionToUnitPosition();
        }
    }
    public Vector2Int LogicPosition
    {
        get => matrixPosition;
        set
        {
            matrixPosition = value;           
            Vector2Int next = TransformRepository.GetSquarePosition(matrixPosition);
            if (next.x < 0 || next.y < 0 || next.x >= GenerateProperty.MapWidth || next.y >= GenerateProperty.MapHeight)
                return;
            if (next != squarePosition)
            {
                TransformRepository.SwitchSquad(squarePosition, next, this);
                OnSquareChange?.Invoke(next,squarePosition);
                squarePosition = next;                
            }
        }
    }
    public void RecalculateMatrixPositionToUnitPosition() => transform.position = MatrixToPosition();
    public int Radius => radius;
    public Vector2Int SquarePosition => squarePosition;
    public void SetActive(bool value) => gameObject.SetActive(value);
    public void Destroy() => Destroy(gameObject);
    public T GetComponent<T>() => gameObject.GetComponent<T>();
    public bool IsContact(Vector2Int pos) => matrixPosition.x - Radius <= pos.x && matrixPosition.x + Radius >= pos.x && matrixPosition.y - Radius <= pos.y && matrixPosition.y + Radius >= pos.y;
    public Vector2Int PositionToMatrix() => PositionToMatrix(transform.position);
    public static Vector2Int PositionToMatrix(Vector3 globalPosition) => PositionToMatrix(globalPosition, GenerateProperty.BlockScale);
    public static Vector2Int PositionToMatrix(Vector3 globalPosition, float blockScale) => new Vector2Int(Mathf.CeilToInt(globalPosition.x / blockScale), Mathf.CeilToInt(globalPosition.z / blockScale));
    public Vector3 MatrixToPosition() => MatrixToPosition(Position, transform.position);
    public static Vector3 MatrixToPosition(Vector2Int matrixPos, Vector3 globalPos) => MatrixToPosition(matrixPos, globalPos, GenerateProperty.BlockScale);
    public static Vector3 MatrixToPosition(Vector2Int matrixPos, Vector3 globalPos, float blockScale) => new Vector3(matrixPos.x * blockScale, globalPos.y, matrixPos.y * blockScale);
    public static Vector2Int CalculateDirection(MatrixTransform to, MatrixTransform from) => CalculateDirection(to.LogicPosition, from.LogicPosition);
    public static Vector2Int CalculateDirection(Vector2Int to, Vector2Int from) => new Vector2Int(Mathf.Clamp(to.x - from.x, -1, 1), Mathf.Clamp(to.y - from.y,-1,1));
}
