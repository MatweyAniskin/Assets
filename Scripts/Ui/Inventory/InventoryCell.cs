using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image cellSprite;
    [SerializeField] Image blockedSprite;
    [SerializeField] int size;
    [SerializeField] Color normalColor;
    [SerializeField] Color specialColor;

    public int Size => size;
    public void SetPosition(Vector2 pos) => rectTransform.anchoredPosition = pos;
    public void SetSpecialColor(bool isSpetial) => cellSprite.color = isSpetial ? specialColor : normalColor;
    public void SetBlock(bool value) => blockedSprite.gameObject.SetActive(value);
}
