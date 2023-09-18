using System;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    [SerializeField] MatrixLoader loader;
    [SerializeField] Tile tile;
    static SimpleBlock[,,] cells;    
    List<Tile> curTiles = new List<Tile>();
    int side;
    private void Start()
    {
        cells = loader.Load();
        side = cells.GetLength(0);      
        InstantiateTile(0,0);  
    }    
    public void SetActiveCells(int fromX, int fromY, int toX, int toY, int radius)
    {
        Vector2Int toMax = new Vector2Int(toX + radius, toY + radius);
        Vector2Int toMin = new Vector2Int(toX - radius, toY - radius);
        Vector2Int fromMax = new Vector2Int(fromX + radius, fromY + radius);
        Vector2Int fromMin = new Vector2Int(fromX - radius, fromY - radius);
        Vector2Int deleteMin = toMax - fromMax;

    }
    Tile InstantiateTile(int x, int y)
    {
        SimpleBlock[,,] tempBlocks = new SimpleBlock[8, 8, 8];
        x *= side;
        y *= side;
        try
        {
            for (int posX = x, i = 0; posX < x + 8; posX++, i++)
            {
                for (int posY = y, j = 0; posY < y + 8; posY++, j++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        tempBlocks[i, j, z] = cells[posX, posY, z];
                    }
                }
            }
            Tile tempTile = Instantiate(tile, new Vector3(x * 8, y * 8, 0), Quaternion.Euler(Vector3.zero), transform) as Tile;
            tempTile.SetBlocks(tempBlocks);
            return tempTile;
        }
        catch
        {
            return null;
        }                
    }   
}
