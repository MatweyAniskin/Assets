using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpecView : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    [SerializeField] float fadeSpeed = 4;
    [SerializeField] CanvasGroup group;
    [SerializeField] Vector2 offset;
    Item curItem;

    void Start()
    {
        /* ItemDragHandler.OnCursorEnd += SetItem;
         ItemDragHandler.OnCursorEnd += DelItem;*/
        InventoryWindow.OnInventoryCellSelect += SetItem;
    }
    private void OnDestroy()
    {
        /*   ItemDragHandler.OnCursorEnd -= SetItem;
           ItemDragHandler.OnCursorEnd -= DelItem;*/
        InventoryWindow.OnInventoryCellSelect -= SetItem;
    }
    void SetItem(ItemCellsIcon itemCellsIcon)
    {
        if(itemCellsIcon is null)
        {
            DelItem();
            return;
        }
        SetItem(itemCellsIcon.GlobalPosition,itemCellsIcon.Item);
    }
    void SetItem(Vector2 pos, Item item)
    {
        rect.anchoredPosition = pos + offset;
        //icon to item
        StartCoroutine(Active());
    }
    void SetItem(Item item)
    {
        curItem = item;
        StartCoroutine(Follow());
        StartCoroutine(Active());
    }
    void DelItem(Item item)
    {
        StartCoroutine(Deactive());
    }
    void DelItem()
    {
        StartCoroutine(Deactive());
    }
    IEnumerator Follow()
    {
        while (!(curItem is null))
        {
            group.transform.position = Input.mousePosition + offset;
            yield return null;
        }
    }
    IEnumerator Active()
    {
        float index = 0;
        while (index < 1 && !(curItem is null))
        {
            index += Time.deltaTime * fadeSpeed;
            group.alpha = index;
            yield return null;
        }
    }
    IEnumerator Deactive()
    {
        float index = 0;
        while (index < 1)
        {
            index += Time.deltaTime * fadeSpeed;
            group.alpha = 1-index;
            yield return null;
        }
        curItem = null;
    }
}
