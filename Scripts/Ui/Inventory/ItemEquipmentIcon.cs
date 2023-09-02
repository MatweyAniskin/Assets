using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipmentIcon : ItemCellsIcon
{
    [SerializeField] GameObject preview;
    [SerializeField] EquipmentTypes.Type equipmentType;
    public override void SetItem(InventoryItem item, float scale)
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
        Vector2 size = new Vector2(item.ScaleX * scale, item.ScaleY * scale);
        SetSize(size);        
        SetRotateSprite(item.Rotate);
    }
    public EquipmentTypes.Type EquipmentType => equipmentType;
}