using UnityEngine;

public class Tile : MonoBehaviour
{    
    [SerializeField] Material material;
    [SerializeField] int side = 8;
    [SerializeField] MeshRenderer renderer;
    [SerializeField] MeshFilter filter;
    [SerializeField] MeshCollider collider;
    SimpleBlock[][][] matrix;    
    public void SetBlocks(SimpleBlock[][][] matrix, Mesh mesh)
    {
        this.matrix = matrix;
        filter.mesh = mesh;
        collider.sharedMesh = mesh;
    }
    public void Destroy() => Destroy(gameObject);
}
