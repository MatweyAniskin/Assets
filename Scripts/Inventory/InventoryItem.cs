using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    [SerializeField] Item item;
    [SerializeField] int x = 0;
    [SerializeField] int y = 0;

    public InventoryItem(Item item, int x, int y)
    {
        this.item = item;
        this.x = x;
        this.y = y;
    }
    public Item Item => item;
    public int PosX => x;
    public int PosY => y;
    public int ScaleX => item.XScale;
    public int ScaleY => item.YScale;
    public int Rotate => item.Rotate;
}
