using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();
    [SerializeField] float maxWeight;
    [SerializeField] float curWeight;

    public delegate void ChangeItemsDelegate(Item item);
    public static event ChangeItemsDelegate OnTakeItem;
    public static event ChangeItemsDelegate OnDropItem;

    private void Start()
    {
        curWeight = 0;
    }
    /// <summary>
    /// Add item with mass calculate
    /// </summary>
    /// <param name="item"></param>
    /// <returns>true - is add, false - is not add</returns>
    public bool TakeItem(Item item)
    {
        if(item.Weight+curWeight > maxWeight)
            return false;
        Add(item);
        OnTakeItem?.Invoke(item);
        return true;
    }
    public void DropItem(Item item)
    {
        OnDropItem?.Invoke(item);
        Remove(item);        
    }

    public void Add(Item item)
    {
        curWeight += item.Weight;
        items.Add(item);
    }
    public void Remove(Item item)
    {
        curWeight -= item.Weight;
        items.Remove(item);
    }
}