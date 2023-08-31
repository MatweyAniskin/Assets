using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpecPanel : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    [SerializeField] float fadeSpeed = 4;
    [SerializeField] CanvasGroup group;
    [SerializeField] Vector2 offset;
    [SerializeField] RectTransform fieldSpec;
    [SerializeField] PropertyView prefabPropertyView;
    [SerializeField] Text itemNameText;
    Item curItem;

    List<PropertyView> propertyViews = new List<PropertyView>();
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
        itemNameText.text = item.ToString();
        itemNameText.color = item.RarityColor;
        PropertyValue[] effectValues = item.GetEffectsValues();
        for(int i = 0; i < effectValues.Length;i++)
        {
            PropertyView view = Instantiate(prefabPropertyView,fieldSpec) as PropertyView;
            view.SetPosition(0, view.Height * i);
            view.SetProperty(effectValues[i]);
            propertyViews.Add(view);
        }
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
        DelItem();
    }
    void DelItem()
    {
        StartCoroutine(Deactive());
        for (int i = 0; i < propertyViews.Count; i++)
        {
            propertyViews[i].Delete();            
        }
        propertyViews.Clear();
    }
    IEnumerator Follow()
    {
        while (!(curItem is null))
        {
         //   group.transform.position = Input.mousePosition + offset;
            yield return null;
        }
    }
    IEnumerator Active()
    {
        float index = 0;
        while (index < 1)
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
