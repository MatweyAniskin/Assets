using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : Window
{
    [SerializeField] InventoryCell cell;
    [SerializeField] RectTransform cellField;
    [SerializeField] ItemCellsIcon cellsIcon;
    InventoryCell[,] cells;

    List<ItemCellsIcon> itemCellsIcons = new List<ItemCellsIcon>();
    Inventory inventory;
    private void Start()
    {
        inventory = PlayerObject.GetComponent<Inventory>();
        cells = new InventoryCell[inventory.Width, inventory.Height];
        float cellSize = cell.Size;        
        cellField.sizeDelta = new Vector2(cellSize * inventory.Width, cellSize * inventory.Height);
        for (int x = 0; x < inventory.Width; x++)
            for (int y = 0; y < inventory.Height; y++)
            {
                var temp = Instantiate(cell, cellField) as InventoryCell;
                temp.SetPosition(new Vector2(x * cellSize, y * -cellSize));
                temp.SetSpecialColor(x < inventory.SecretWidth && y < inventory.SecretHeight);
                cells[x, y] = temp;
            }
        UpdateBlockedCells();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (WindowController.IsOpened)
            {
                this.Close();
            }
            else
            {
                this.Open();
            }

        }
    }
    protected override void OnOpen()
    {
        DrawItems();
    }
    void DrawItems()
    {
        InventoryItem[] inventoryItems = inventory.Items;
        foreach (var i in inventoryItems)
        {
            ItemCellsIcon temp = Instantiate(cellsIcon, cellField) as ItemCellsIcon;
            temp.SetItem(i, cell.Size);
            itemCellsIcons.Add(temp);
            UpdateBlockedCells(i);
        }        
    }
    void UpdateBlockedCells(InventoryItem inventoryItem)
    {
        for (int x = inventoryItem.PosX; x < inventoryItem.PosX + inventoryItem.ScaleX; x++)
            for (int y = inventoryItem.PosY; y < inventoryItem.PosY + inventoryItem.ScaleY; y++)
                cells[x, y].SetBlock(true);
    }
    void UpdateBlockedCells()
    {
        for (int x = 0; x < inventory.Width; x++)
            for (int y = 0; y < inventory.Height; y++)
                cells[x, y].SetBlock(inventory.GetBlock(x,y));
    }
    void ClearBlockedCells()
    {
        for (int x = 0; x < inventory.Width; x++)
            for (int y = 0; y < inventory.Height; y++)
                cells[x, y].SetBlock(false);
    }
    protected override void OnClose()
    {
        for (int i = 0; i < itemCellsIcons.Count; i++)
        {
            itemCellsIcons[i].Destroy();
        }
        itemCellsIcons.Clear();
        ClearBlockedCells();
    }
}
