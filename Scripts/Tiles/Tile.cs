using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{    
    [SerializeField] Material material;
    [SerializeField] int side = 8;
    MeshRenderer renderer;
    MeshFilter filter;
    MeshCollider collider;
    public void SetBlocks(Block[,,] blocks)
    {
        filter = gameObject.AddComponent<MeshFilter>();
        renderer = gameObject.AddComponent<MeshRenderer>();
        collider = gameObject.AddComponent<MeshCollider>();
        renderer.material = material;
        Mesh mesh = new Mesh();
        List<CombineInstance> combines = new List<CombineInstance>();                        
        for (int x = 0; x < side; x++)
        {
            for (int y = 0; y < side; y++)
            {
                for (int z = 0; z < side; z++)
                {
                    if (blocks[x, y,z] is null)
                        continue;
                    blocks[x, y, z].Instantiate(transform, x, y, z, ref combines);
                }                
            }
        }
        mesh.CombineMeshes(combines.ToArray());
        filter.mesh = mesh;
        collider.sharedMesh = mesh;
    }
    /* void Instantiate()
     {
         filter = gameObject.AddComponent<MeshFilter>();
         renderer = gameObject.AddComponent<MeshRenderer>();
         renderer.material = material;
         List<Vector3> vertices = new List<Vector3>();
         List<int> triangles = new List<int>();
         List<Vector2> uv = new List<Vector2>();

         Vector3[] tempVertices;
         int[] tempTriangles;
         Vector2[] tempUvs;        
         Mesh mesh = new Mesh();        
         for (int x = 0; x < 8; x++)
         {
             for (int y = 0; y < 8; y++)
             {
                 tempVertices = block.Vertices;
                 for (int i = 0; i < tempVertices.Length; i++)
                 {
                     tempVertices[i].x += x;
                     tempVertices[i].y += y;
                     vertices.Add(tempVertices[i]);
                 }
                 tempTriangles = block.Triangles;
                 for (int i = 0; i < tempVertices.Length; i++)
                 {
                     tempTriangles[i] += 
                     vertices.Add(tempVertices[i]);
                 }                
                 triangles.AddRange(block.Triangles);
                 uv.AddRange(block.Uv);
             }
         }
         mesh.vertices = vertices.ToArray();
         mesh.triangles = triangles.ToArray();
         mesh.uv = uv.ToArray();
         filter.mesh = mesh;
     }*/
}
