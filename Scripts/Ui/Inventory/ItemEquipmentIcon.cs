using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipmentIcon : ItemCellsIcon
{
    [SerializeField] GameObject preview;
    [SerializeField] EquipmentTypes.Type equipmentType;
    public override void SetItem(InventoryItem item)
    {       
        this.item = item;
        if (item.Item is null)
        {
            preview.SetActive(true);
            SetActiveIcon(false);
            return;
        }
        preview.SetActive(false);
        SetActiveIcon(true);
        SetIcon(item.Item.Icon);                
    }
    public EquipmentTypes.Type EquipmentType => equipmentType;
}