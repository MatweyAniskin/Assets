using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCellsIcon : IconWithShadow
{
    [SerializeField] float selectAnimationSpeed = 4;
    [SerializeField] Vector3 standartScale = Vector3.one;
    [SerializeField] Vector3 selectedScale = new Vector3(1.25f, 1.25f, 1.25f);
    
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
        StartCoroutine(SelectAnimation(true));
    }
    public void OnUnSelected()
    {
        StartCoroutine(SelectAnimation(false));
    }
    IEnumerator SelectAnimation(bool isSelect)
    {
        float index = 0;
        Vector3 to = isSelect ? selectedScale : standartScale;
        Vector3 from = isSelect ? standartScale : selectedScale;
        while (index < 1)
        {
            index += Time.deltaTime * selectAnimationSpeed;            
            transform.localScale = Vector3.Lerp(from, to,index);
            yield return null;
        }
    }
}
