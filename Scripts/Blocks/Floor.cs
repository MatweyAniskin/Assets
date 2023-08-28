using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block", menuName = "Blocks/Block Floor")]
public class Floor : Block
{
    [SerializeField] protected Mesh mesh;
    [SerializeField] Vector2 uvOffset;
    [SerializeField] float zOffset = 0;
    public override void Instantiate(Transform transform, int x, int y, int z, ref List<CombineInstance> combines)
    {
        Mesh temp = new Mesh();
        temp.vertices = mesh.vertices;
        temp.triangles = mesh.triangles;
        temp.normals = mesh.normals;
        Vector2[] uvs = mesh.uv;
        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = UvMap(uvOffset, uvs[i]);
        }
        temp.uv = uvs;
        CombineInstance tempInstance = new CombineInstance();
        tempInstance.mesh = temp;
        Matrix4x4 matrix = transform.worldToLocalMatrix;
        matrix.m03 += x + transform.position.x;
        matrix.m23 += y + transform.position.z;
        matrix.m13 = transform.position.y + zOffset;
       // matrix = Matrix4x4.Rotate(Quaternion.Euler(0, rotation, 0));
        tempInstance.transform = matrix;
        combines.Add(tempInstance);
    }
}
