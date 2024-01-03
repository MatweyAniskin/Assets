using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] protected Image icon;
    [SerializeField] protected RectTransform rect;
    public virtual void SetElement(IViewElement element) => SetIcon(element.Icon);
    /// <summary>
    /// Set anchored position for this rect
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    public void SetPosition(float x, float y) => SetPosition(new Vector2(x, y));
    /// <summary>
    /// Set anchored position for this rect
    /// </summary>
    /// <param name="position">Position coordinate</param>
    public void SetPosition(Vector2 position) => Position = position;
    /// <summary>
    /// Set rect size
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetSize(float width, float height) => SetSize(new Vector2(width, height));
    /// <summary>
    /// Set rect size
    /// </summary>
    /// <param name="size"></param>
    public void SetSize(Vector2 size) => rect.sizeDelta = size;  
    /// <summary>
    /// Rect width
    /// </summary>
    public float Width => rect.rect.width;
    /// <summary>
    /// Rect height
    /// </summary>
    public float Height => rect.rect.height;
    /// <summary>
    /// Rect position
    /// </summary>
    public Vector2 GlobalPosition => rect.position;
    public Vector2 Position
    {
        get => rect.anchoredPosition;
        set => rect.anchoredPosition = value;
    }
    public Color IconColor
    {
        get => icon.color;
        set => icon.color = value;
    }
    public virtual void SetActiveIcon(bool value) => icon.gameObject.SetActive(value);
    public virtual void SetIcon(Sprite icon) => this.icon.sprite = icon;
    public void SetRotateSprite(int rotate) => icon.transform.rotation = Quaternion.Euler(0, 0, rotate);
    public virtual void Destroy() => Destroy(gameObject);
}
