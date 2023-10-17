using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMatrixTransform : MatrixTransform
{
    public delegate void UpdateTransform(MatrixTransform transform);
    public static event UpdateTransform OnSetStartPosition;
    public override void SetStartPosition(Vector2Int globalposition)
    {
        OnSetStartPosition?.Invoke(this);
        base.SetStartPosition(globalposition);
    }
}
