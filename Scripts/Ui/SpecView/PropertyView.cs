using UnityEngine;
using UnityEngine.UI;

public abstract class PropertyView : Icon
{
    [SerializeField] protected Text valueText;
    public abstract void SetProperty(PropertyValue effectValue);

    public void Delete() => Destroy(gameObject);
}
