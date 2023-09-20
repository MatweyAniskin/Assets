using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleBlock : ScriptableObject
{    
    [SerializeField] protected int rotation;
    [SerializeField] protected BlockMaterial material;
    protected float scale = 1;
    protected static Vector2 UvMap(Vector2 index, Vector2 curPoint)
    {
        int side = 16;
        float sideLarge = 1f / side;
        curPoint *= sideLarge;        
        curPoint += new Vector2(index.x * sideLarge, index.y * sideLarge);        
        return curPoint;                
    }    
    public abstract void Instantiate(int x, int y, int z, ref List<Vector3> vertex, ref List<int> triangles, SimpleBlock[ , , ] matrix);
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
}
