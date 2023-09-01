using UnityEngine;
using UnityEngine.UI;

public class IconWithShadow : Icon
{
    [SerializeField] Image shadowImage;

    public override void SetIcon(Sprite icon)
    {
        base.SetIcon(icon);
        this.shadowImage.sprite = icon;
    }
    public override void SetActiveIcon(bool value)
    {
        base.SetActiveIcon(value);
        shadowImage.gameObject.SetActive(value);
    }
}

