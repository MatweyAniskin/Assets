using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    [SerializeField] protected Item item;
    [SerializeField] int count = 0;

    public InventoryItem(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }
    public InventoryItem(Item item)
    {
        this.item = item;        
    }
    public void AddCount(int count) => this.count += count;
    public void RemoveCount(int count) => this.count -= count;
    public Item Item => item;
    public int Count => count;
    public override string ToString()
    {
        return item.ToString();
    }
}
