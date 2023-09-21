using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCache
{
    [SerializeField] string name;
    [SerializeField] Mesh mesh;
    SimpleBlock[,,] matrix;

    public Mesh TileMesh => mesh;
    public SimpleBlock[,,] Blocks => matrix;

    public TileCache(SimpleBlock[,,] matrix)
    {        
        this.matrix = matrix;
        int count = matrix.GetLength(0);
        mesh = new Mesh();
        List<Vector3> vertex = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();
        for (int x = 0; x < count; x++)
            for (int y = 0; y < count; y++)
                for (int z = 0; z < count; z++)
                    if (matrix[x,y,z] is null)
                        continue;
                    else
                        matrix[x,y,z].Instantiate(x, y, z, ref vertex, ref triangles, ref uvs, matrix);
        mesh.vertices = vertex.ToArray();
        mesh.triangles = triangles.ToArray();               
        mesh.uv = uvs.ToArray();        
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
    
    public override string ToString() => name;

    public static bool operator ==(TileCache a, string b) => a.name == b;
    public static bool operator !=(TileCache a, string b) => a.name != b;
}
