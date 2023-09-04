using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryEquipmentItem : InventoryItem
{
    [SerializeField] EquipmentTypes.Type equipment;
    public InventoryEquipmentItem(Item item) : base(item, 1)
    {
    }
    public Item SetItem(Item item) => this.item = item;
    public EquipmentTypes.Type Equipment { get { return equipment; } }
}
