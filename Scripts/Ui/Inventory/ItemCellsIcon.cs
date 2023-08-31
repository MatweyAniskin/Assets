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
    
    InventoryItem item;

    public Item Item => item.Item;
    public int PosX => item.PosX;
    public int PosY => item.PosY;
    public Vector2 Pos => new Vector2(PosX, PosY);
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
