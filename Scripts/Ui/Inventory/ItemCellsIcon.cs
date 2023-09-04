using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCellsIcon : IconWithShadow
{
    [SerializeField] float selectAnimationSpeed = 4;
    [SerializeField] GameObject selectRamp;
    [SerializeField] Vector3 standartScale = Vector3.one;
    [SerializeField] Vector3 maxScale = new Vector3(1.25f, 1.25f, 1.25f);
    [SerializeField] float animationSpeed = 4;
    
    protected InventoryItem item;

    public Item Item => item.Item;    
    public Vector2 Pos => rect.anchoredPosition;
    public virtual void SetItem(InventoryItem item, Vector2 position)
    {
        this.item = item;
        SetIcon(item.Item.Icon);        
        SetPosition(position);        
    }
    public virtual void SetItem(InventoryItem item)
    {
        this.item = item;
        SetIcon(item.Item.Icon);        
    }
    public void OnSelected()
    {
        selectRamp.SetActive(true);
        StartCoroutine(SelectAnimation());
    }
    public void OnUnSelected()
    {
        selectRamp.SetActive(false);
    }    
    IEnumerator SelectAnimation()
    {
        float index = 0;
        Transform rampTransform = selectRamp.transform;
        while (index < 1)
        {
            index += Time.deltaTime * animationSpeed;
            rampTransform.localScale = Vector3.Lerp(maxScale, standartScale, index);
            yield return null;
        }
    }
}
