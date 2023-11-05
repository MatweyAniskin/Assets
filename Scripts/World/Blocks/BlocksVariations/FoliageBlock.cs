using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Foliage", menuName = "Blocks/Foliage")]
public class FoliageBlock : SimpleBlock
{
    const float angle = 0.5f;
    public override void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int>[] triangles, ref List<Vector2> uvs, SimpleBlock[,,] matrix)
    {     
        vertex.Add(new Vector3(0, 0, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(angle, 1, 0) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(0, 0, 1) * GenerateProperty.BlockScale + Offset(x, y, z));
        vertex.Add(new Vector3(angle, 1, 1) * GenerateProperty.BlockScale + Offset(x, y, z));

        GenerateUvMap(ref uvs);

        triangles[trianglesArray].Add(vertex.Count - 2);
        triangles[trianglesArray].Add(vertex.Count - 3);
        triangles[trianglesArray].Add(vertex.Count - 4);

        triangles[trianglesArray].Add(vertex.Count - 1);
        triangles[trianglesArray].Add(vertex.Count - 3);
        triangles[trianglesArray].Add(vertex.Count - 2);
    }
}
