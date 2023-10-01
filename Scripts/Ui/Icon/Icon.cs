using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] protected Image icon;
    [SerializeField] protected RectTransform rect;
    public virtual void SetElement(IViewElement element)
    {
        SetIcon(element.Icon);
    }
    public void SetPosition(float x, float y) => SetPosition(new Vector2(x, y));
    public void SetPosition(Vector2 position) => rect.anchoredPosition = position;
    public void SetSize(float width, float height) => SetSize(new Vector2(width, height));
    public void SetSize(Vector2 size) => rect.sizeDelta = size;    
    public float Width => rect.rect.width;
    public float Height => rect.rect.height;
    public Vector2 GlobalPosition => rect.position;
    public virtual void SetActiveIcon(bool value) => icon.gameObject.SetActive(value);
    public virtual void SetIcon(Sprite icon) => this.icon.sprite = icon;
    public void SetRotateSprite(int rotate) => icon.transform.rotation = Quaternion.Euler(0, 0, rotate);
    public void Destroy() => Destroy(gameObject);
}
