using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    protected Item item;
    public delegate void ChangeDropIcon(Item item);
    public static event ChangeDropIcon OnCursorDrag;
    public static event ChangeDropIcon OnCursorEnd;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(item);
        OnCursorDrag?.Invoke(item);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnCursorEnd?.Invoke(item);
    }
}
