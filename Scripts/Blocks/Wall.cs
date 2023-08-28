using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block", menuName = "Blocks/Block Wall")]
public class Wall : Block
{
    [SerializeField] protected Mesh mesh;
    [SerializeField] Vector2 outsideUv;
    [SerializeField] Vector2 insideUv;
    
    [SerializeField] int[] insideUvValue;
    [SerializeField] int[] outsideUvValue;
    public override void Instantiate(Transform transform, int x, int y, int z, ref List<CombineInstance> combines)
    {
        Mesh temp = new Mesh();
        temp.vertices = mesh.vertices;
        temp.triangles = mesh.triangles;
        temp.normals = mesh.normals;
        Vector2[] uvs = mesh.uv;


        for (int i = 0; i < outsideUvValue.Length; i++)
        {
            uvs[outsideUvValue[i]] = UvMap(outsideUv, uvs[outsideUvValue[i]]);
            uvs[insideUvValue[i]] = UvMap(insideUv, uvs[insideUvValue[i]]);
        }        
        temp.uv = uvs;
        CombineInstance tempInstance = new CombineInstance();
        tempInstance.mesh = temp;        
        Matrix4x4 matrix = transform.worldToLocalMatrix;
        matrix *= Matrix4x4.Rotate(Quaternion.Euler(0, rotation, 0));
        matrix.m03 += x + transform.position.x;
        matrix.m23 += y + transform.position.z;
        matrix.m13 = 0;
        tempInstance.transform = matrix;
        combines.Add(tempInstance);
    }
}
