using UnityEngine;

public class Tile : MonoBehaviour
{    
    [SerializeField] MeshRenderer renderer;
    [SerializeField] MeshFilter filter;
    [SerializeField] MeshCollider collider;
    SimpleBlock[,,] matrix;    
    public void SetBlocks(SimpleBlock[,,] matrix, Mesh mesh)
    {
        this.matrix = matrix;
        filter.mesh = mesh;
        collider.sharedMesh = mesh;
    }
    public void SetBlocks(TileCache tileCache)
    {
        this.matrix = tileCache.Blocks;
        filter.mesh = tileCache.TileMesh;
        collider.sharedMesh = tileCache.TileMesh;
    }
    public void SetPosition(Vector3 pos) => transform.position = pos;
    public void Destroy() => Destroy(gameObject);
}
