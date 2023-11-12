using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : Window
{
    [SerializeField] ItemViewBlock itemViewPrefab;
    [SerializeField] RectTransform itemViewField;
    [SerializeField] Vector2 itemsBlockOffset;
    protected override void OnClose()
    {
        base.OnClose();
    }

    protected override void OnOpen()
    {
        Item[] items = Inventory.GetItems();
        float height = itemViewPrefab.Height;
        ItemViewBlock temp;
        itemViewField.sizeDelta = new Vector2(itemViewPrefab.Width, height*items.Length);
        for (int i = 0; i < items.Length; i++)
        {
            temp = Instantiate(itemViewPrefab, itemViewField) as ItemViewBlock;
            temp.SetElement(items[i]);
            temp.SetPosition(itemsBlockOffset.x, -(height + itemsBlockOffset.y) * i);
        }
    }
}
