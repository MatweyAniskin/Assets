using System;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    [SerializeField] MatrixLoader loader;
    [SerializeField] Tile tile;
    static Block[,,] cells;
    static ColliderCell[,,] colliders;
    Tile[,] curTiles;
    int side, tilesCount;    
    private void Start()
    {
        cells = loader.Load();
        side = cells.GetLength(0);
        CalculateColliders();
        InstantiateTile(0,0);  
    }
    public void CalculateColliders()
    {
        colliders = new ColliderCell[side, side, 1];
        for (int x = 0; x < side; x++)
        {
            for (int y = 0; y < side; y++)
            {
                ColliderCell collider = new ColliderCell();
                for (int z = 0; z < 8; z++)
                {
                    if (cells[x,y,z] is null)
                        continue;
                    collider += cells[x,y,z];
                }
                colliders[x, y, 0] = collider;
            }
        }
        Debug.Log($"CollidersArray X: {colliders.GetLength(0)}, Y: {colliders.GetLength(1)}, Side: {side}");
    }
    Tile InstantiateTile(int x, int y)
    {
        Block[,,] tempBlocks = new Block[8, 8,8];
        for (int posX = x * side, i = 0; posX < x + 8; posX++, i++)
        {
            for (int posY = y * side, j = 0; posY < y + 8; posY++, j++)
            {
                for (int z = 0; z < 8; z++)
                {
                    tempBlocks[i, j, z] = cells[posX, posY,z];
                }                
            }
        }
        Tile tempTile = Instantiate(tile, new Vector3(x * 8, y * 8, 0), Quaternion.Euler(Vector3.zero), transform) as Tile;
        tempTile.SetBlocks(tempBlocks);
        return tempTile;
    }
    public static bool IsCollision(Vector2 direction, Vector3Int position) => IsCollision(new Vector2Int(Convert.ToInt32(direction.x), Convert.ToInt32(direction.y)), position);
    public static bool IsCollision(Vector2Int direction, Vector3Int position)
    {        
        //Debug.Log($"Inside: {colliders[position.x, position.y, 0].IsInsideCollision(direction)}, Outside: {colliders[position.x, position.y, 0].IsOutsideCollision(direction)}");
        return colliders[position.x, position.y, 0].IsInsideCollision(direction)
        || colliders[position.x + direction.x, position.y + direction.y, 0].IsOutsideCollision(direction);
    }
}
