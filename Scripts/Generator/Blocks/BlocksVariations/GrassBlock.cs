using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Grass", menuName = "Blocks/Grass")]
public class GrassBlock : SimpleBlock
{
    public override void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs, SimpleBlock[,,] matrix)
    {
        //Right
        vertex.Add(new Vector3(0, 0, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 0, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));

        GenerateUvMap(ref uvs);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);
       

        //Left
        vertex.Add(new Vector3(0, 0, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(0, 1, 1)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 0, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));
        vertex.Add(new Vector3(1, 1, 0)  * GenerateProperty.BlockScale + Offset(x,y,z));

        GenerateUvMap(ref uvs);

        triangles.Add(vertex.Count - 4);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 1);
    }
}
