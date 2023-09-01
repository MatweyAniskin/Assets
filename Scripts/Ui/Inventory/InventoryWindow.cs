using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWindow : Window
{
    [SerializeField] InventoryCell cell;
    [SerializeField] RectTransform cellField;
    [SerializeField] ItemCellsIcon cellsIcon;
    InventoryCell[,] cells;

    List<ItemCellsIcon> itemCellsIcons = new List<ItemCellsIcon>();
    Inventory inventory;

    public delegate void InventoryCellDelegate(ItemCellsIcon item);
    public static event InventoryCellDelegate OnInventoryCellSelect;   
    ItemCellsIcon selectedItem = null;
    ItemCellsIcon SelectedItem
    {
        get { return selectedItem; }
        set
        {
            if (value == selectedItem)
                return;
            if (selectedItem != null)
                selectedItem.OnUnSelected();
            selectedItem = value;
            OnInventoryCellSelect?.Invoke(selectedItem);
            if (selectedItem != null)
                selectedItem.OnSelected();
        }
    }
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
    void Update() //unit
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

        StartCoroutine(InputWithKey());
    }
    protected override void OnClose()
    {
        SelectedItem = null;
        for (int i = 0; i < itemCellsIcons.Count; i++)
        {
            itemCellsIcons[i].Destroy();
        }
        itemCellsIcons.Clear();
        ClearBlockedCells();
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
                cells[x, y].SetBlock(inventory.GetBlock(x, y));
    }
    void ClearBlockedCells()
    {
        for (int x = 0; x < inventory.Width; x++)
            for (int y = 0; y < inventory.Height; y++)
                cells[x, y].SetBlock(false);
    }
    IEnumerator InputWithKey() //to new input
    {
        float horizontal;
        float vertical;
        while (isOpen && itemCellsIcons.Count != 0)
        {
            yield return null;
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if (horizontal != 0 || vertical != 0)
            {
                Vector2 dir = new Vector2(horizontal, -vertical);                
                if (SelectedItem != null)
                {                   
                    SelectedItem = GetNear(SelectedItem, dir);
                }
                else
                    SelectedItem = GetNear(0, 0, dir);
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
    ItemCellsIcon GetNear(ItemCellsIcon itemCellsIcon, Vector2 dir) => GetNear(itemCellsIcon.PosX, itemCellsIcon.PosY, dir);
    ItemCellsIcon GetNear(int curX, int curY, Vector2 dir)
    {
        if (itemCellsIcons.Count == 1)
            return itemCellsIcons.FirstOrDefault();
        ItemCellsIcon near = null;
        dir.x += curX;
        dir.y += curY;
        float distance = 0;
        float minDistance = 0;
        foreach (var icon in itemCellsIcons)
        {
            if (icon == SelectedItem)
                continue;
            distance = Vector2.Distance(icon.Pos, dir);
            if (distance < minDistance || near is null)
            {
                minDistance = distance;
                near = icon;
            }
        }
        return near;
    }
}
