using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransformSquare
{
    List<MatrixTransform> transforms = new List<MatrixTransform>();

    public void Add(MatrixTransform transform) => transforms.Add(transform);
    public void Remove(MatrixTransform transform) => transforms?.Remove(transform);
    public MatrixTransform GetContact(Vector2Int globalPosition) => transforms?.FirstOrDefault(i=> i.IsContact(globalPosition));
    public IEnumerable<MatrixTransform> GetTransforms => transforms;
}
