using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int cellHeight = 8;
    [SerializeField] int cellWidth = 4;
    [SerializeField] int secretHeight = 3;
    [SerializeField] int secretWidth = 4;

    List<InventoryItem> inventoryItems = new List<InventoryItem>();
    bool[,] blockedCells;
    public int Height => cellHeight;
    public int Width => cellWidth;
    public int SecretHeight => secretHeight;
    public int SecretWidth => secretWidth;

    private void Awake()
    {
        inventoryItems.Clear();
        blockedCells = new bool[cellWidth, cellHeight];
    }
    private void OnDestroy()
    {

    }
    public bool TakeItem(Drop drop) => TakeItem(drop.GetItem());
    public bool TakeItem(Item item)
    {        
        int xSize = item.XScale;
        int ySize = item.YScale;
        for (int x = 0; x <= cellWidth - xSize; x++)
            for (int y = 0; y <= cellHeight - ySize; y++)
            {
                if (CheckCells(x, y, xSize, ySize))
                {                    
                    SetItem(item, x, y);
                    return true;
                }

            }

        return false;
    }
    public InventoryItem[] Items => inventoryItems.ToArray();
    public void SetItem(Item item, int x, int y)
    {
        inventoryItems.Add(new InventoryItem(item, x, y));
        BlockCells(x, y, item.XScale, item.YScale);
    }
    public void ReSetItem(InventoryItem item, int x, int y)
    {
        inventoryItems.Remove(item);
        UnBlockCells(x, y, item.Item.XScale, item.Item.YScale);
    }
    bool CheckCells(int x, int y, int scaleX, int scaleY)
    {
        for (int i = x; i < x + scaleX; i++)
            for (int j = y; j < y + scaleY; j++)
            {
                if (blockedCells[i, j])
                    return false;
            }
        return true;
    }
    public bool GetBlock(int x, int y) => blockedCells[x, y];
    void BlockCells(int x, int y, int scaleX, int scaleY) => BlockCells(x, y, scaleX, scaleY, true);
    void UnBlockCells(int x, int y, int scaleX, int scaleY) => BlockCells(x, y, scaleX, scaleY, false);
    void BlockCells(int x, int y, int scaleX, int scaleY, bool value)
    {        
        for (int i = x; i < x + scaleX; i++)        
            for (int j = y; j < y + scaleY; j++)            
                blockedCells[i, j] = value;                                     
    }
}
