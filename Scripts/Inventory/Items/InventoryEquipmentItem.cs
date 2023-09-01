using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryEquipmentItem : InventoryItem
{
    [SerializeField] EquipmentTypes.Type equipment;
    public InventoryEquipmentItem(Item item, int x, int y) : base(item, x, y)
    {
    }
    public Item SetItem(Item item) => this.item = item;
    public EquipmentTypes.Type Equipment { get { return equipment; } }
}
