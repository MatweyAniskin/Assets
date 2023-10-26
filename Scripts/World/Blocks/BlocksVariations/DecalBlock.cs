using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Decal", menuName = "Blocks/Decal")]
public class DecalBlock : SimpleBlock
{
    [SerializeField] float vertexOffset = 0.8f;
    public override void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int>[] triangles, ref List<Vector2> uvs, SimpleBlock[,,] matrix)
    {
        if (!IsNotBlocks(x, y, z + 1, matrix)) DrawFront(x, y, z, ref vertex, ref triangles[trianglesArray], ref uvs);
        if (!IsNotBlocks(x, y, z - 1, matrix)) DrawBack(x, y, z, ref vertex, ref triangles[trianglesArray], ref uvs);
        if (!IsNotBlocks(x + 1, y, z, matrix)) DrawRight(x, y, z, ref vertex, ref triangles[trianglesArray], ref uvs);
        if (!IsNotBlocks(x - 1, y, z, matrix)) DrawLeft(x, y, z, ref vertex, ref triangles[trianglesArray], ref uvs);
        if (!IsNotBlocks(x, y - 1, z, matrix)) DrawDown(x, y, z, ref vertex, ref triangles[trianglesArray], ref uvs);
        
    }

    void DrawFront(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(0, 0, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(0, vertexOffset, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, 0, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, vertexOffset, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));


        triangles.Add(vertex.Count - 4);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 1);
        
        GenerateUvMap(ref uvs);
    }
    void DrawBack(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(0, 0, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(0, vertexOffset, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, 0, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, vertexOffset, 0) * GenerateProperty.BlockScale + Offset(x, y, z));

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        GenerateUvMap(ref uvs);
    }
    void DrawRight(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(vertexOffset, 0, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, vertexOffset, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, 0, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, vertexOffset, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));
        
        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        GenerateUvMap(ref uvs);
    }
    
    void DrawLeft(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(0, 0, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(0, vertexOffset, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(0, 0, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(0, vertexOffset, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));

        triangles.Add(vertex.Count - 4);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 1);

        GenerateUvMap(ref uvs);
    }
    void DrawDown(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(0, 1-vertexOffset, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, 1 - vertexOffset, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(0, 1 - vertexOffset, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(vertexOffset, 1 - vertexOffset, vertexOffset) * GenerateProperty.BlockScale + Offset(x, y, z));

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);
        GenerateUvMap(ref uvs);
    }
}
