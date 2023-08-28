using UnityEngine;
using UnityEngine.UI;

public class IconWithShadow : Icon
{
    [SerializeField] Image shadowImage;

    public override void SetIcon(Sprite icon)
    {
        this.icon.sprite = icon;
        this.shadowImage.sprite = icon;
    }
}

