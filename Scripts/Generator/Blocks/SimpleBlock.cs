using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleBlock : ScriptableObject
{    
    [SerializeField] protected Vector2Int textureCoordinate;
    [SerializeField] protected BlockMaterial material;
    public static float BlockScale {get; set; } =1;
    public static float UvSideCountTextures 
    { 
        get
        {
            return uvSideCountTextures;
        } 
        set
        {
            uvSideCountTextures = value;
            uvScale = 1f / uvSideCountTextures;
        }
    }

    protected static float uvSideCountTextures = 1;    
    protected static float uvScale = 1f;

    protected void GenerateUvMap(ref List<Vector2> uvs)
    {
        uvs.Add(new Vector2(textureCoordinate.x, textureCoordinate.y)*uvScale);
        uvs.Add(new Vector2(textureCoordinate.x, textureCoordinate.y+1) * uvScale);
        uvs.Add(new Vector2(textureCoordinate.x+1, textureCoordinate.y) * uvScale);
        uvs.Add(new Vector2(textureCoordinate.x + 1, textureCoordinate.y+1) * uvScale);
    }    
    public abstract void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, ref List<Vector2> uvs, SimpleBlock[ , , ] matrix);
    protected bool IsNotBlocks(int x, int y, int z, SimpleBlock[ , , ] matrix)
    {
        try
        {
            return !(matrix[x,y,z].GetType() == typeof(Block));
        }
        catch
        {
            return true;
        }
    }
    protected Vector3 Offset(int x, int y, int z) => new Vector3(x, y, z) * BlockScale;
}
