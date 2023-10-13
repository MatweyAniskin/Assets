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
        gameObject.name = tileCache.ToString();
    }
    public void SetPosition(Vector2Int pos) => SetPosition(pos.x, pos.y);
    public void SetPosition(int x, int y) => transform.localPosition = new Vector3(x*GenerateProperty.TileSideScale,0, y * GenerateProperty.TileSideScale);
    /// <summary>
    /// Set active tile in scene
    /// </summary>
    /// <param name="value">is active</param>
    public void SetActive(bool value) => gameObject.SetActive(value);
    public void Destroy() => Destroy(gameObject);
}
