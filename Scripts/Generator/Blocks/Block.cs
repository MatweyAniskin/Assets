using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : SimpleBlock
{
    
    public override void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, SimpleBlock[,,] matrix)
    {
        if (IsNotBlocks(x,y,z+1,matrix)) DrawFront(ref vertex, ref triangles);
        if (IsNotBlocks(x, y, z - 1, matrix)) DrawBack(ref vertex, ref triangles);
        if (IsNotBlocks(x+1, y, z, matrix)) DrawRight(ref vertex, ref triangles);
        if (IsNotBlocks(x - 1, y, z, matrix)) DrawLeft(ref vertex, ref triangles);
        if (IsNotBlocks(x, y + 1, z, matrix)) DrawTop(ref vertex, ref triangles);        
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
