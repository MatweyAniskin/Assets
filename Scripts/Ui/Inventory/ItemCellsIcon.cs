using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCellsIcon : IconWithShadow
{
    InventoryItem item;
    public void SetItem(InventoryItem item, float scale)
    {
        this.item = item;
        SetIcon(item.Item.Icon);
        Vector2 pos = new Vector2(item.PosX * scale, -item.PosY * scale);
        Vector2 size = new Vector2(item.ScaleX * scale, item.ScaleY * scale);
        SetSize(size);
        SetPosition(pos);
        SetRotateSprite(item.Rotate);
    }
}
