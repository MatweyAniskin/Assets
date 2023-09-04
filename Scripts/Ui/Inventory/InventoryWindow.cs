using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWindow : Window
{
    [SerializeField] InventoryCell cell;
    [SerializeField] RectTransform cellField;
    [SerializeField] ItemCellsIcon cellsIcon;
    [SerializeField] Vector2 itemsListDirection = Vector2.down;
    [SerializeField] ItemEquipmentIcon[] equipmentIcons;    
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
        UpdateEquipment();     
    }
    protected override void OnClose()
    {
        SelectedItem = null;
        for (int i = 0; i < itemCellsIcons.Count; i++)
        {
            itemCellsIcons[i].Destroy();
        }
        itemCellsIcons.Clear();        
    }
    void DrawItems()
    {
        InventoryItem[] inventoryItems = inventory.Items;
        for(int i = 0; i<inventoryItems.Length; i++) 
        {
            ItemCellsIcon temp = Instantiate(cellsIcon, cellField) as ItemCellsIcon;
            temp.SetItem(inventoryItems[i], itemsListDirection * i * temp.Height);
            itemCellsIcons.Add(temp);            
        }
    }    
    void UpdateEquipment()
    {
        foreach (var i in equipmentIcons)
        {            
            i.SetItem(inventory.GetEquipmqment(i.EquipmentType));
        }
    }          
}
