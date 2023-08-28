using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : ScriptableObject
{    
    [SerializeField] protected int rotation;
    [SerializeField] protected BlockMaterial material;
    [SerializeField] ColliderCell collider;
    protected static Vector2 UvMap(Vector2 index, Vector2 curPoint)
    {
        int side = 16;
        float sideLarge = 1f / side;
        curPoint *= sideLarge;        
        curPoint += new Vector2(index.x * sideLarge, index.y * sideLarge);        
        return curPoint;                
    }    
    public abstract void Instantiate(Transform transform, int x, int y, int z, ref List<CombineInstance> combines);

    public ColliderCell Collider => collider;   
}
