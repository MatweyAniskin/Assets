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
    Vector2Int tileIndex;
    public int X => tileIndex.x;
    public int Y => tileIndex.y;
    public void SetTileIndex(int x, int y) => tileIndex = new Vector2Int(x, y);
    public void SetBlocks(SimpleBlock[,,] blocks)
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
    public void Destroy() => Destroy(gameObject);
}
