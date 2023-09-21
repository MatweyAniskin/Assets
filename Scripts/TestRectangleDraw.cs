using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRectangleDraw : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] float scale = 1;
    private void Start()
    {
        Mesh mesh = new Mesh();
        
        List<Vector3> vertex = new List<Vector3>();
        List<Vector2> uv = new List<Vector2>();
        List<int> triangles = new List<int>();

        //back
        vertex.Add(new Vector3(0,0,0) * scale);
        vertex.Add(new Vector3(0,1,0) * scale);
        vertex.Add(new Vector3(1, 0, 0) * scale);
        vertex.Add(new Vector3(1, 1, 0) * scale);

        uv.Add(new Vector2(0, 0));
        uv.Add(new Vector2(0, 1));
        uv.Add(new Vector2(1, 0));
        uv.Add(new Vector2(1, 1));

        triangles.Add(vertex.Count - 4);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 1);

        //front
        /*vertex.Add(new Vector3(0, 0, 1) * scale);
        vertex.Add(new Vector3(0, 1, 1) * scale);
        vertex.Add(new Vector3(1, 0, 1) * scale);
        vertex.Add(new Vector3(1, 1, 1) * scale);

        triangles.Add(vertex.Count - 2);        
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);        
        triangles.Add(vertex.Count - 2);

        //left
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

        //right
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

        //top
        vertex.Add(new Vector3(0, 1, 0) * scale);
        vertex.Add(new Vector3(1, 1, 0) * scale);
        vertex.Add(new Vector3(0, 1, 1) * scale);
        vertex.Add(new Vector3(1, 1, 1) * scale);

        triangles.Add(vertex.Count - 2);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 4);

        triangles.Add(vertex.Count - 1);
        triangles.Add(vertex.Count - 3);
        triangles.Add(vertex.Count - 2);*/


        mesh.vertices = vertex.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}
