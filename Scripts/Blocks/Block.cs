using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : SimpleBlock
{
    float scale = 1;
    public override void Instantiate(Transform transform, int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles)
    {
        
    }
    void DrawFront(ref List<Vector3> vertex, ref List<int> triangles)
    {
        vertex.Add(new Vector3(0, 0, 1) * scale);
        vertex.Add(new Vector3(0, 1, 1) * scale);
        vertex.Add(new Vector3(1, 0, 1) * scale);
        vertex.Add(new Vector3(1, 1, 1) * scale);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);
    }
    void DrawRight(ref List<Vector3> vertex, ref List<int> triangles)
    {
        vertex.Add(new Vector3(1, 0, 0) * scale);
        vertex.Add(new Vector3(1, 1, 0) * scale);
        vertex.Add(new Vector3(1, 0, 1) * scale);
        vertex.Add(new Vector3(1, 1, 1) * scale);

        triangles.Add(vertex.Count - 4);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 1);
    }
    void DrawBack(ref List<Vector3> vertex, ref List<int> triangles)
    {
        vertex.Add(new Vector3(0, 0, 0) * scale);
        vertex.Add(new Vector3(0, 1, 0) * scale);
        vertex.Add(new Vector3(1, 0, 0) * scale);
        vertex.Add(new Vector3(1, 1, 0) * scale);

        triangles.Add(vertex.Count - 4);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 1);
    }
    void DrawLeft(ref List<Vector3> vertex, ref List<int> triangles)
    {
        vertex.Add(new Vector3(0, 0, 0) * scale);
        vertex.Add(new Vector3(0, 1, 0) * scale);
        vertex.Add(new Vector3(0, 0, 1) * scale);
        vertex.Add(new Vector3(0, 1, 1) * scale);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);
    }
    void DrawTop(ref List<Vector3> vertex, ref List<int> triangles)
    {
        vertex.Add(new Vector3(0, 1, 0) * scale);
        vertex.Add(new Vector3(1, 1, 0) * scale);
        vertex.Add(new Vector3(0, 1, 1) * scale);
        vertex.Add(new Vector3(1, 1, 1) * scale);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);
    }
}
