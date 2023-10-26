using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleBlock : ScriptableObject
{    
    [SerializeField] protected Vector2Int[] textureCoordinate;
    [SerializeField] protected BlockMaterial material;
    [SerializeField] private bool isSolid;
    [SerializeField] protected int trianglesArray = 0;
    float uvOffset = 0f;
    public bool IsSolid => isSolid;
    protected void GenerateUvMap(ref List<Vector2> uvs)
    {
        Vector2Int textureCoordinate = this.textureCoordinate[Random.Range(0, this.textureCoordinate.Length)];
        uvs.Add(new Vector2(textureCoordinate.y - uvOffset, GenerateProperty.UvSideCountTextures.y - textureCoordinate.x - 1 + uvOffset) * GenerateProperty.UvScale);
        uvs.Add(new Vector2(textureCoordinate.y - uvOffset, GenerateProperty.UvSideCountTextures.y - textureCoordinate.x - uvOffset) * GenerateProperty.UvScale);        
        uvs.Add(new Vector2(textureCoordinate.y + 1 - uvOffset, GenerateProperty.UvSideCountTextures.y - textureCoordinate.x - 1 + uvOffset) * GenerateProperty.UvScale);
        uvs.Add(new Vector2(textureCoordinate.y + 1 - uvOffset, GenerateProperty.UvSideCountTextures.y - textureCoordinate.x - uvOffset) * GenerateProperty.UvScale);
        

/*        uvs.Add(new Vector2(textureCoordinate.y, GenerateProperty.UvSideCountTextures - textureCoordinate.x)* GenerateProperty.UvScale);
        uvs.Add(new Vector2(textureCoordinate.y, GenerateProperty.UvSideCountTextures - textureCoordinate.x-1) * GenerateProperty.UvScale);
        uvs.Add(new Vector2(textureCoordinate.y +1, GenerateProperty.UvSideCountTextures - textureCoordinate.x) * GenerateProperty.UvScale);
        uvs.Add(new Vector2(textureCoordinate.y + 1, GenerateProperty.UvSideCountTextures - textureCoordinate.x-1) * GenerateProperty.UvScale);
  */
        }    
    public abstract void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int>[] triangles, ref List<Vector2> uvs, SimpleBlock[ , , ] matrix);
    protected bool IsNotBlocks(int x, int y, int z, SimpleBlock[ , , ] matrix)
    {
        try
        {
            return !(matrix[x,y,z].isSolid);            
        }
        catch
        {
            return true;
        }
    }
    protected Vector3 Offset(int x, int y, int z) => new Vector3(x, y, z) * GenerateProperty.BlockScale;
}
