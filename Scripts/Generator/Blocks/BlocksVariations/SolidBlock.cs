using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Block", menuName = "Blocks/Block")]
public class SolidBlock : SimpleBlock
{    
    public override void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int>[] triangles,ref List<Vector2> uvs, SimpleBlock[,,] matrix)
    {       
        if (IsNotBlocks(x,y,z+1,matrix)) DrawFront(x,y,z,ref vertex, ref triangles[0], ref uvs);
        if (IsNotBlocks(x, y, z - 1, matrix)) DrawBack(x, y, z, ref vertex, ref triangles[0], ref uvs);
        if (IsNotBlocks(x+1, y, z, matrix)) DrawRight(x, y, z, ref vertex, ref triangles[0], ref uvs);
        if (IsNotBlocks(x - 1, y, z, matrix)) DrawLeft(x, y, z, ref vertex, ref triangles[0], ref uvs);
        if (IsNotBlocks(x, y + 1, z, matrix)) DrawTop(x, y, z, ref vertex, ref triangles[0], ref uvs);        
    }
   
    void DrawFront(int x, int y,int z,ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(0, 0, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 0, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));

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
        vertex.Add(new Vector3(1, 0, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 0, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));

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
        vertex.Add(new Vector3(0, 0, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 0, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));

        triangles.Add(vertex.Count - 4);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 1);
        GenerateUvMap(ref uvs);
    }
    void DrawLeft(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(0, 0, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 0, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);
        GenerateUvMap(ref uvs);
    }
    void DrawTop(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs)
    {
        vertex.Add(new Vector3(0, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);
        GenerateUvMap(ref uvs);
    }
}
