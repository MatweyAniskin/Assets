using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] float maxWeightBase = 20;    
    [SerializeField] InventoryEquipmentItem[] inventoryEquipmentItems;
    [SerializeField] float maxAddWeight = 0;
    [SerializeField] float overloadWeight = 0;
    float curWeight = 0;

    List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public delegate void ChangeWeightDelegate(float weight);
    public event ChangeWeightDelegate OnChangeWeight;
    public event ChangeWeightDelegate OnChangeMaxWeight;
    public delegate void ChangeInventoryItems();
    public event ChangeInventoryItems OnInventoryItemsChange;
    float Weight
    {
        get => curWeight;
        set
        {
            curWeight = value;
            OnChangeWeight?.Invoke(curWeight);
        }
    }
    float MaxWeight
    {
        get => maxWeightBase + maxAddWeight;
        set
        {
            maxAddWeight = value;
            OnChangeMaxWeight?.Invoke(MaxWeight);
        }
    }    

    private void Awake()
    {
        inventoryItems.Clear();        
    }
    private void OnDestroy()
    {

    }
    public InventoryItem GetEquipmqment(EquipmentTypes.Type type) => inventoryEquipmentItems.FirstOrDefault(i => i.Equipment == type);
    public bool AddItem(Drop drop) => AddItem(drop.GetItem(),drop.Count);
    public bool AddItem(Item item, int count)
    {
        if (maxWeightBase + maxAddWeight + overloadWeight - Weight < item.Weight*count)
            return false;
        SetItem(item,count);
        return true;
    }    
    public InventoryItem[] Items => inventoryItems.ToArray();

    InventoryItem GetInventoryItem(Item item)
    {
        InventoryItem inventoryItem = inventoryItems.Where(i => i.Item == item).FirstOrDefault();
        if (inventoryItem == null)
        {
            inventoryItem = new InventoryItem(item);
            inventoryItems.Add(inventoryItem);
            return inventoryItem;
        }
        return inventoryItem;
    }
    public void SetItem(Item item, int count)
    {
        GetInventoryItem(item).AddCount(count);
        Weight += item.Weight * count;
        OnInventoryItemsChange?.Invoke();
    }
    public void RemoveItem(Item item, int count)
    {
        InventoryItem itemInventory = GetInventoryItem(item);
        if (itemInventory.Count <= count)
            inventoryItems.Remove(itemInventory);
        else
            itemInventory.RemoveCount(count);
        Weight -= item.Weight * count;
        OnInventoryItemsChange?.Invoke();
    }
    public void RemoveItem(Item item)
    {        
        inventoryItems.Remove(GetInventoryItem(item));        
        OnInventoryItemsChange?.Invoke();
    }
}